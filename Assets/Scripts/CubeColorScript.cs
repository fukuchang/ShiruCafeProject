using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeColorScript : MonoBehaviour {

    public bool m_isTrigger = false;
    public Color m_color;
    public float distance = 0;
    public float m_denominator;
    public Color m_changedColor; //変更後の色の比率を確認するためのスクリプト

    [SerializeField]
    private float m_changeSpeed = 4f;
    private float ratio;
    private Color m_preColor;

    ParticleSystem ps;

	void Start () {
        m_preColor = m_color;
        m_denominator = 30; //膨張するSphereの最大半径を入れる
        ps = gameObject.transform.parent.GetComponent<ParticleSystem>();
	}

	void Update () {
        if(m_preColor != m_color){
            ratio = distance / m_denominator;
            BlendColor(ratio);
        }
	}

    //遠くなればなるほどCubeの伝播された色が薄くなる関数
    void BlendColor(float blendRatio){
        var col = ps.colorOverLifetime;
        var main = ps.main;
        main.startColor = m_color;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { /*new GradientColorKey(m_color, 0f), */new GradientColorKey(m_color, 1f) },
                     new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 1.0f) });
        Debug.Log(m_color);
        col.color = grad;
        m_changedColor = m_color;
        m_preColor = m_color;
    }
}
