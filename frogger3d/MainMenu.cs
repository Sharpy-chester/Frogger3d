using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public Button button;
	// Use this for initialization
	void Start () {
		Button start = button.GetComponent<Button> ();
		start.onClick.AddListener (TaskOnClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void TaskOnClick(){
		print ("pressed");
		Application.LoadLevel ("scene");
	}
}
