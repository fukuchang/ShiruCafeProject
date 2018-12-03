﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereColorScript : MonoBehaviour {

    public Color m_color;
    public GameObject[] m_target;
    public bool m_isChangeColor = false;
    public float m_colliderRadius;

    Material m_Material;
    Color m_preColor;
    GameObject childSphere;
    SphereCollider m_sphereCollider;

	// Use this for initialization
	void Awake () {
        m_Material = this.GetComponent<Renderer>().material;
        m_preColor = m_color;
        childSphere = gameObject.transform.Find("Sphere").gameObject;
        m_sphereCollider = childSphere.GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        if(m_isChangeColor){
            m_isChangeColor = false;
            StartCoroutine("Wait");
        }

        if(m_preColor != m_color){
            m_isChangeColor = true;
            childSphere.SetActive(true);
            m_colliderRadius = m_sphereCollider.radius;
            m_Material.DOBlendableColor(m_color, 5).SetEase(Ease.OutSine);
            m_preColor = m_color;

        }
       
	}

    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        childSphere.SetActive(false);
    }
}
