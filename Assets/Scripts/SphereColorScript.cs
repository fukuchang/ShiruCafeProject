using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereColorScript : MonoBehaviour {

    Material m_Material;
    public Color m_color;
    Color m_preColor;

	// Use this for initialization
	void Awake () {
        m_Material = this.GetComponent<Renderer>().material;
        m_preColor = m_color;
	}
	
	// Update is called once per frame
	void Update () {
        if(m_preColor != m_color){
            m_Material.DOBlendableColor(m_color, 10).SetEase(Ease.OutSine);
            m_preColor = m_color;
        }
       
	}
}
