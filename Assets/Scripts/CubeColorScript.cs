using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeColorScript : MonoBehaviour {

    Material m_material;

    public bool m_isTrigger = false;
    public Color m_color;
    public float distance = 0;
    public float m_denominator;
    public Color m_changedColor; //変更後の色の比率を確認するためのスクリプト

    [SerializeField]
    private float m_changeSpeed = 5f;
    private float ratio;
    private Color m_preColor;
    //private Color m_changedColor;

	// Use this for initialization
	void Start () {
        m_material = this.GetComponent<Renderer>().material;
        m_preColor = m_color;
	}
	
	// Update is called once per frame
	void Update () {
        if(m_preColor != m_color){
            ratio = distance / m_denominator;
            BlendColor(ratio);
        }
	}

    void BlendColor(float blendRatio){
        m_color = m_color + m_color * blendRatio;
        m_material.DOBlendableColor(m_color, m_changeSpeed * blendRatio).SetEase(Ease.InQuart);
        m_changedColor = m_color;
        m_preColor = m_color;
    }
}
