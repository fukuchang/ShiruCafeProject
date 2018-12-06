using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereTriggerScript : MonoBehaviour {

    SphereColorScript SCS;
    bool m_isExpansion;
    Material m_material;
    Color m_preColor;
    Color m_aftColor;

	// Use this for initialization
	void Start () {
        SCS = gameObject.transform.parent.GetComponent<SphereColorScript>();
        m_isExpansion = false;
        m_material = this.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if(SCS.m_isChangeColor && !m_isExpansion){
            m_preColor = SCS.m_color;
            m_preColor.a = 0.5f;
            m_material.color = m_preColor;
            m_aftColor = m_preColor;
            m_aftColor.a = 0.025f;
            m_material.DOBlendableColor(m_aftColor, 10).SetEase(Ease.OutSine);
            m_isExpansion = true;
        }

        if(m_isExpansion){
            if (gameObject.transform.localScale.x >= 30f)
            {
                m_isExpansion = false;
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            gameObject.transform.localScale += new Vector3(5f, 5f, 5f) * Time.deltaTime;
        }


	}
}
