using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SearchCubeScript : MonoBehaviour {

    //public GameObject m_parent;
    SphereColorScript SCS;
    CubeColorScript CCS;

    void OnTriggerEnter(Collider col){
        if(col.tag == "Search"){
            Vector3 cubePos = gameObject.transform.position;
            Vector3 spherePos = col.gameObject.transform.position;
            Vector3 diffPos = cubePos - spherePos;

            CCS = gameObject.GetComponent<CubeColorScript>();
            SCS = col.gameObject.transform.parent.GetComponent<SphereColorScript>();

            CCS.m_denominator = SCS.m_colliderRadius;
            CCS.distance = diffPos.magnitude;
            CCS.m_color = SCS.m_color;

        }
    }
}
