using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SearchCubeScript : MonoBehaviour {

    //public GameObject m_parent;
    //SphereColorScript SCS;
    FireColorScript FCS;
    CubeColorScript CCS;

    void OnTriggerEnter(Collider col){
        if(col.tag == "Search"){
            Debug.Log("Trigger");
            Vector3 cubePos = gameObject.transform.position;
            Vector3 spherePos = col.gameObject.transform.position;
            Vector3 diffPos = cubePos - spherePos;

            CCS = gameObject.GetComponent<CubeColorScript>();
            //SCS = col.gameObject.transform.parent.GetComponent<SphereColorScript>();
            FCS = col.gameObject.transform.parent.GetComponent<FireColorScript>();

            //CCS.m_denominator = SCS.m_colliderRadius;
            //CCS.m_denominator = col.gameObject.transform.localScale.x / 2;
            CCS.distance = diffPos.magnitude;
            //CCS.m_color = SCS.m_color;
            CCS.m_color = FCS.m_color;

        }
    }
}
