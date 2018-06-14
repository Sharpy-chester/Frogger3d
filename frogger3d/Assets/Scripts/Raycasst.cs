using UnityEngine;
using System.Collections;

public class Raycasst : MonoBehaviour {

	private Transform thisTransform = null;
	//private Transform objhit = null;
	//private Transform newxpos = null;

	// Use this for initialization
	void Start () {
		thisTransform = GetComponent<Transform> ();	}
	
	// Update is called once per frame
	void Update () {
		var forward = thisTransform.TransformDirection (Vector3.left);
		RaycastHit hit;
		Debug.DrawRay (thisTransform.position, -forward * 10, Color.green);

		if (Physics.Raycast (thisTransform.position, -forward, out hit, 10)) {
			Debug.Log ("hit");
			//objhit = hit.collider.gameObject;
			//print(objhit.transform.position.x;
			//newxpos = objhit.transform.position.x;
			//transform.position += new Vector3(0f
		}
		
		
	}
}
