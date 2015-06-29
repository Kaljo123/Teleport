using UnityEngine;
using System.Collections;

public class NetworkUnit : Photon.MonoBehaviour {

	private Vector3 realPosition = Vector3.zero;
	private Quaternion realRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (photonView.isMine) {

		} else {

			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, 0.1f);
		}

	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

		if (stream.isWriting) {
			//send

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		} else {
			//receive
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}

	}
}
