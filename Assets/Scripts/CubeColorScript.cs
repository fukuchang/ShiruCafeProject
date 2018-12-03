using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeColorScript : MonoBehaviour {

    Material m_material;
    public bool m_isTrigger = false;
    public Color m_color;

    private Color m_preColor;

	// Use this for initialization
	void Start () {
        m_material = this.GetComponent<Renderer>().material;
        m_preColor = m_color;
	}
	
	// Update is called once per frame
	void Update () {
        if(m_preColor != m_color){
            m_material.DOBlendableColor(m_color, 5).SetEase(Ease.InQuart);
            m_preColor = m_color;

        }
	}
}
