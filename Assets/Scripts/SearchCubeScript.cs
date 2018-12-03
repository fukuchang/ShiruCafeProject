using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SearchCubeScript : MonoBehaviour {

    //public GameObject m_parent;
    SphereColorScript SCS;
    CubeColorScript CCS;

	// Use this for initialization
	void Start () {
        //SCS = m_parent.GetComponent<SphereColorScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col){
        if(col.tag == "Search"){
            Debug.Log("Stay!");
            CCS = gameObject.GetComponent<CubeColorScript>();
            SCS = col.gameObject.transform.parent.GetComponent<SphereColorScript>();
            Debug.Log(SCS.m_color);
            CCS.m_color = SCS.m_color;
        }
    }
}
