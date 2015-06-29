using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class NetoworkManager : MonoBehaviour {

	private bool joined = false;
	private bool problem = false;
	
	// Use this for initialization
	void Start() {
		Connect();
	}
	
	void Connect() {
		try {
			PhotonNetwork.ConnectUsingSettings("myRTS v001");
		}
		catch(System.Exception e) {
			problem = true;
		}
	}
	
	void OnGUI() {
		if (!joined)
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		if(problem) {
			GUILayout.Label("CHECK YOUR INTERNET CONNECTION");
		}
	}
	
	void OnJoinedLobby() {
		Debug.Log("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log("OnPhotonRandomJoinFailed");
		/*RoomOptions roomOptions = new RoomOptions() { isVisible = true, maxPlayers = 2 };
        PhotonNetwork.CreateRoom(null, roomOptions, TypedLobby.Default);*/
		PhotonNetwork.CreateRoom(null);
	}
	
	void OnJoinedRoom() {
		Debug.Log("OnJoinedRoom");
		joined = true;
		SpawnMyPlayer();
	}
	
	void SpawnMyPlayer() {

		GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate ("Warrior", new Vector3(0,5,0), Quaternion.identity, 0);

		myPlayer.transform.FindChild ("MainCamera").gameObject.SetActive (true);
		((MonoBehaviour)myPlayer.GetComponent<RigidbodyFirstPersonController> ()).enabled = true;

	}
}









