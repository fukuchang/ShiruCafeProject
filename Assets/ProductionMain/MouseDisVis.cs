using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDisVis : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
