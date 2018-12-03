using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeScript : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
	}
}
