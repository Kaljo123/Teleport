using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour {

	public GameObject player;
	public Animator anim;


	public float distance = 5f;
	public KeyCode teleportLeft = KeyCode.Q;
	public KeyCode teleportRight = KeyCode.E;
	public KeyCode teleportForward = KeyCode.F;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (teleportForward)) {
			player.transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * distance;
		}

		if (Input.GetKeyDown(teleportLeft)){
			player.transform.position -= transform.right * distance;
		}

		if (Input.GetKeyDown(teleportRight)){
			player.transform.position += transform.right * distance;
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			player.transform.position += new Vector3(0,1,0) * distance;
		}

		if (Input.GetMouseButtonDown(0)){
			attack();
		}

	}

	private void attack(){
		anim.SetTrigger ("click");
	}

}



