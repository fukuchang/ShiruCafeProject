using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireTriggerScript : MonoBehaviour {

    FireColorScript FCS;
    bool m_isExpansion;
    //Material m_material;
    Color m_preColor;
    Color m_aftColor;
    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        FCS = gameObject.transform.parent.GetComponent<FireColorScript>();
        m_isExpansion = false;
        ps = gameObject.transform.parent.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if(FCS.m_isChangeColor && !m_isExpansion){
            m_preColor = FCS.m_color;
            //var col = ps.colorOverLifetime;
            //var main = ps.main;
            //Gradient grad = new Gradient();
            //grad.SetKeys(new GradientColorKey[] { new GradientColorKey(m_aftColor, 1f) },
            //             new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) });
            //col.color = grad;
            if(m_preColor.r == 1f && m_preColor.g == 1f && m_preColor.b == 0f){
                m_isExpansion = false;
            }else{
                m_isExpansion = true;
            }
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
