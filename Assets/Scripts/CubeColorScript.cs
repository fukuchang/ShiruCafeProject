using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeColorScript : MonoBehaviour {

    Material m_material;
    public Color m_color = Color.black;

	// Use this for initialization
	void Start () {
        m_material = this.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            m_material.DOBlendableColor(m_color, 5).SetEase(Ease.InQuart);
        }
	}
}
