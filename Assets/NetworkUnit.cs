using UnityEngine;
using System.Collections;

public class NetworkUnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

		if (stream.isWriting) {
			//send

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		} else {
			//receive
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();
		}

	}
}
