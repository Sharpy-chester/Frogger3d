using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunrotate : MonoBehaviour {
	public float rotspeed = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * rotspeed * Time.deltaTime, Space.World) ;
		transform.Rotate (Vector3.up * rotspeed * Time.deltaTime, Space.World) ;
	}
}
