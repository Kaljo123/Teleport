using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {

	public Collider playerBody;

	void Start(){
		Physics.IgnoreCollision (playerBody, GetComponent<Collider> ());
	}

	void OnCollisionEnter(Collision col){
		col.gameObject.SendMessage ("hit", SendMessageOptions.DontRequireReceiver);
	}
}
