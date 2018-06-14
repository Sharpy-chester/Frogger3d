using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour {
	//Variables
	public float speed = 10f;
	public Text counttext;
	public Text wintext;
	private Scene scene;
	private float time = 0f;
	public Text timetext;
	public Text check1;
	public Text check2;
	public Text lifetext;
	public Text gameover;
	public GameObject[] Count;
	public GameObject[] Count2;
	private float lives = 3f;
	private float Count2fix;

	void start (){
		scene = SceneManager.GetActiveScene ();
	}
	void Update () {
		Count = GameObject.FindGameObjectsWithTag("Coin");
		Count2 = GameObject.FindGameObjectsWithTag("Coin2");
		Count2fix = Count2.Length - 1;
		timerthing ();
		countthing ();
		Lives ();
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
		if (col.gameObject.tag == "carleft") {
			print ("hit");
			lives = lives - 1f;
			if (lives >= 0) {
				lifetext.text = "Lives: " + lives;
			}
		}
		if (col.gameObject.tag == "carright") {
			print ("hit");
			lives = lives - 1f;
			if (lives >= 1) {
				lifetext.text = "Lives: " + lives;
			}
		}
		if (col.gameObject.tag == "Coin") {
			print (Count.Length);
			Destroy (col.gameObject);
			counttext.text = "Coins Left: " + Count.Length.ToString ();
			StartCoroutine (wall ());
			if (Count.Length == 1) {
				check1.text = "Checkpoint One: " + time.ToString ("F2");
			}
		}
		if (col.gameObject.tag == "Coin2") {
			Destroy (col.gameObject);
			print (Count2.Length);
			StartCoroutine (wall ());
			counttext.text = "Coins Left: " + Count2fix.ToString ();
			if (Count2.Length == 1) {
				
				check2.text = "Checkpoint Two: " + time.ToString ("F2");
			}
		}
	}
	void timerthing(){
		if (lives >= 1) { 
			if (Count2.Length >= 1) {
				time += 1f * Time.deltaTime;
				timetext.text = "Time: " + time.ToString ("F2");
			}
		}
	}
	IEnumerator wall(){
		if (Count.Length == 1){
			print ("working");
			wintext.text = "Level Complete! Unlocking New Area...                 " +ToString ();
			yield return new WaitForSeconds (5);
			wintext.text = "";
			GameObject.Find ("gate").SetActive (false);
			counttext.text = "Coins Left: " + Count2fix.ToString ();
		}
		if (Count2.Length == 1){
			print ("working");
			wintext.text = "Level Complete! Unlocking New Area...                 " +ToString ();
			yield return new WaitForSeconds (5);
			wintext.text = "";
			GameObject.Find ("gate2").SetActive (false);
		}

	}
	void countthing(){
		if (GameObject.Find ("gate") != null) {
			counttext.text = "Coins Left: " + Count.Length.ToString ();
		}
	}
	void Lives(){
		
		if (lives >= 1) {
			
			lifetext.text = "Lives: " + lives;

			Movement ();
		} 
		else{
			gameover.text = "Game Over";
		}
	}
}