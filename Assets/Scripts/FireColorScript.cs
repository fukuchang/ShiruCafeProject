using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColorScript : MonoBehaviour {

    public Color m_color;
    public bool m_isChangeColor = false;
    public float m_colliderRadius;
    public GameObject m_System;
    public int m_Num;

    Color m_preColor;
    GameObject childSphere;
    SphereCollider m_sphereCollider;
    ColorDataManager CDM;
    ParticleSystem ps;

	private void Awake()
	{
        childSphere = gameObject.transform.Find("Sphere").gameObject;
        m_sphereCollider = childSphere.GetComponent<SphereCollider>();
        CDM = m_System.gameObject.GetComponent<ColorDataManager>();
        m_preColor = CDM.cols[m_Num];
        ps = gameObject.GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update () {
        if(m_isChangeColor){
            m_isChangeColor = false;
            StartCoroutine("Wait");
        }

        if(m_preColor != CDM.cols[m_Num]){
            m_color = CDM.cols[m_Num];
        }

        if(m_preColor != m_color){
            m_isChangeColor = true;
            m_colliderRadius = m_sphereCollider.radius;
            var col = ps.colorOverLifetime;
            var main = ps.main;
            main.startColor = m_color;
            Gradient grad = new Gradient();
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(m_color, 1f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 1.0f) });
            col.color = grad;
            m_preColor = m_color;
        }
	}

    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
    }
}
