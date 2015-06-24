using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public float width = 100;
	public float height = 100;

	void OnGUI(){
		GUI.Box (new Rect((Screen.width - width)/2, (Screen.height - height)/2, width, height), "dsadsads");
	}

}
