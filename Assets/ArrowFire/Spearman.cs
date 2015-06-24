using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Spearman : MonoBehaviour {

	public struct Args{
		public float power;
		public Collider col;

		public Args(float p, Collider c){
			power = p; col = c;
		}
	};

	public GameObject player;

	public GameObject spearPrefab;
	public Collider col; //player's collider

	private GameObject lastSpear;

	float power = 0;
	public float deltaPower = 50;
	public float powerLimit = 5000;
	public float powerMin = 300;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			power = powerMin;
		}

		if (Input.GetMouseButtonUp (0)) {

			Args args = new Args(power, col);

			GameObject spear = (GameObject)Instantiate(spearPrefab, transform.position, transform.rotation);
			lastSpear = spear;
			spear.GetComponent<Spear>().SendMessage("fire", args, SendMessageOptions.DontRequireReceiver);
			/*Physics.IgnoreCollision(spear.GetComponent<Collider>(), col);
			spear.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power);
			spear.transform.Rotate(90,0,0);*/

			power = 0;
		}

		if (power > 0 && power <= powerLimit) {
			power += deltaPower;
			if (power>powerLimit) power = powerLimit;
		}

		if (Input.GetMouseButtonDown (1)) {
			if (lastSpear!=null){
				player.transform.position = lastSpear.transform.FindChild("EndOfSpear").transform.position;


				Destroy(player.GetComponent<RigidbodyFirstPersonController>());
				player.transform.Rotate(0,180,0);
				player.AddComponent<RigidbodyFirstPersonController>();

				Destroy(lastSpear);
			}
		}

	}

	void OnGUI(){
		GUI.Box(new Rect(50, 50, 100, 30), power + "");
	}
}
