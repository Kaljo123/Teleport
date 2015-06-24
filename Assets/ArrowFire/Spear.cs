using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

	bool flying = true;
	float power;

	Quaternion lastRot;
	Vector3 lastPos;
	Vector3 nextPos;


	float timeLimit = 15f;
	float timePassed = 0f;
	float timeStarted = 0f;

	GameObject anchor; //used for sticking in rigidbodies

	// Use this for initialization
	void Start () {
	
	}

	void fire(Spearman.Args args){
		this.power = args.power;

		Physics.IgnoreCollision(GetComponent<Collider>(), args.col);
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power);
		transform.Rotate(90,0,0);
	}

	// Update is called once per frame
	void Update () {
		if (flying) {
			rotation ();
			lastRot = transform.rotation;
			lastPos = transform.position;
			nextPos = lastPos + GetComponent<Rigidbody> ().velocity * Time.deltaTime / 5;
		} else {
			timePassed = Time.time - timeStarted;
			if (timePassed > timeLimit) Destroy (gameObject);

			if (anchor != null){
				transform.position = anchor.transform.position;
				transform.rotation = anchor.transform.rotation;
			}
		}


	}

	void rotation(){
		transform.LookAt (transform.position + GetComponent<Rigidbody> ().velocity);
		transform.Rotate (90, 0, 0);
	}

	void OnCollisionEnter(Collision col){ //not totally ok for object with rigidbody but acceptable

		if (flying) {
			flying = false;
			timeStarted = Time.time;


			GetComponent<Rigidbody>().velocity = Vector3.zero;

			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<Collider> ().enabled = false;
			transform.rotation = lastRot;
			transform.position = nextPos;//lastPos;

			if (col.gameObject.GetComponent<Rigidbody>()!=null){
				anchor = new GameObject("anchor");
				Debug.Log(col.contacts.Length);

				anchor.transform.position = transform.position;
				anchor.transform.rotation = transform.rotation;
				anchor.transform.parent = col.transform;

				transform.position = anchor.transform.position;
				transform.rotation = anchor.transform.rotation;
			}

		}

	}
}
