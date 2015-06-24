using UnityEngine;
using System.Collections;

public class FireArrow : MonoBehaviour {

	public Transform startPoint;
	public GameObject prefab;
	public Collider col;
	GameObject arrow;

	float flyLimit = 10f;
	float timeFlying = 0f;
	float startedFlying;

	bool thrown = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){
			timeFlying = 0f;
			startedFlying = Time.time;

			//arrow.transform.position = startPoint.position;
			//arrow.transform.rotation = startPoint.rotation

			arrow = (GameObject)Instantiate (prefab, startPoint.position + new Vector3(0,0,0), startPoint.rotation);
			Physics.IgnoreCollision(col, arrow.GetComponent<Collider>());

			arrow.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
			arrow.transform.Rotate(90,0,0);
			thrown = true;
		}


		if (thrown) {
			rotate ();
			timeFlying = Time.time - startedFlying;

			if (timeFlying > flyLimit) {
				thrown = false;
			}
		}

	}

	void rotate()
	{	
		arrow.transform.LookAt(arrow.transform.position + arrow.GetComponent<Rigidbody>().velocity);	
		arrow.transform.Rotate (90, 0, 0);
	}

	void hit(){
		thrown = false;
	}


}
