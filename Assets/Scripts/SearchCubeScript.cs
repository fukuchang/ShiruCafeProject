using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SearchCubeScript : MonoBehaviour {

    FireColorScript FCS;
    CubeColorScript CCS;

    void OnTriggerEnter(Collider col){
        if(col.tag == "Search"){
            Debug.Log("Trigger");
            Vector3 cubePos = gameObject.transform.position;
            Vector3 spherePos = col.gameObject.transform.position;
            Vector3 diffPos = cubePos - spherePos;

            CCS = gameObject.GetComponent<CubeColorScript>();
            FCS = col.gameObject.transform.parent.GetComponent<FireColorScript>();
            CCS.distance = diffPos.magnitude;
            CCS.m_color = FCS.m_color;

        }
    }
}
