using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		Destroy (this.GetComponent<Rigidbody>());
		Camera.current.gameObject.GetComponent<FireArrow> ().SendMessage ("hit", SendMessageOptions.DontRequireReceiver);
	}
}
