using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public float width = 10;
	public float height = 10;

	void OnGUI(){
		GUI.Box (new Rect((Screen.width - width)/2, (Screen.height - height)/2, width, height), "*");
	}

}
