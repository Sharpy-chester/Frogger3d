using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour {
    public float speed = 10f;
    public Text counttext;
    public Text wintext;
    private Scene scene;
    public float time = 0f;
    public Text timetext;
    public GameObject[] count;
    public GameObject[] finalCount;
	public float gravity = 0f;
    public float wait;


	void start (){
		scene = SceneManager.GetActiveScene ();
	}
	// Update is called once per frame
	void Update () {
		count = GameObject.FindGameObjectsWithTag("Coin");
        finalCount = GameObject.FindGameObjectsWithTag("finalCoin");
		transform.position += new Vector3 (0f, -gravity, 0f);
		Movement ();
		timerthing ();
		restart ();
		counttext.text = "Coins Left: " + count.Length.ToString ();
		gate ();
        NextLevel();
	}
	void Movement(){
		if (Input.GetKey ("a")) {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey ("d")) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey ("w")) {
			transform.position += new Vector3 (0f, 0f, speed * Time.deltaTime);
		}
		if (Input.GetKey ("s")) {
			transform.position += new Vector3 (0f, 0f, -speed * Time.deltaTime);
		}

	}
	void OnCollisionEnter (Collision col){
		//if (count.Length >=1) {
			if (col.gameObject.tag == "car") {
				print ("hit");
				SceneManager.LoadScene ("scene");
			}
		//}
		if (col.gameObject.tag == "Coin") {
			print (count.Length);
			Destroy (col.gameObject);
		}

	}	
		
	void restart (){
		if (finalCount.Length == 0){
			wintext.text = "You Win!   Press Space to Play Again " +ToString ();
			timetext.text = "Your Time Was: " + time.ToString  ();
			if (Input.GetKeyDown(KeyCode.Space)){
				SceneManager.LoadScene ("scene");
			}
			
		}
	
	}

    void NextLevel()
    {
        if (count.Length == 0)
        {
            
            float timething = Time.time - wait;
            if (Time.time <= time)
            {
                wintext.text = "Level complete. Wait " + timething + " seconds";
                Debug.Log("ayyyyy"); //only runs this once
            }
            else
            {
                wintext.text = "";
                
            }
        }
        else
        {
            float time = Time.time + wait; //i think this is the problem. Need brain to work properly
            Debug.Log(time); //runs this as expected
        }
    }

	void timerthing(){
		if (finalCount.Length >= 1) {
			time += 1f * Time.deltaTime;
			timetext.text = "Time: " + time.ToString("F2");
		}

	}
	void gate(){
		if (count.Length ==0) {
			GameObject.Find("gate").SetActive (false);
			
		}

	}
}