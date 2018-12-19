using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireColorScriptPre : MonoBehaviour {

    public Color m_color; //変更される色(espから受け取られる色)
    public bool m_isChangeColor = false; //色が変わったかどうかの真偽値
    public float m_colliderRadius; //色を変えるCubeを認識どこまで認識するか(Colliderの半径)
    public string keyword; //Test Code キーボード用の文字
    public GameObject System;
    public int m_Num;

    Material m_Material;
    Color m_preColor; //変わる前の色
    GameObject childSphere;
    SphereCollider m_sphereCollider;
    ColorDataManager CDM;

    ParticleSystem ps;

    void Awake () {
        //m_Material = this.GetComponent<Renderer>().material;
        //m_preColor = m_color;
        childSphere = gameObject.transform.Find("Sphere").gameObject;
        m_sphereCollider = childSphere.GetComponent<SphereCollider>();
        ps = gameObject.GetComponent<ParticleSystem>();
        CDM = System.gameObject.GetComponent<ColorDataManager>();
        m_preColor = CDM.cols[m_Num];
    }

    void Update () {
        
        if(m_isChangeColor){
            m_isChangeColor = false;
            StartCoroutine("Wait");
        }

        Debug.Log(/*CDM.cols[m_Num].ToString() + */"Test" + m_Num.ToString());

        if(m_preColor != CDM.cols[m_Num]){
            m_color = CDM.cols[m_Num];
            Debug.Log(m_color.ToString()+"Test");
        }

        if(m_preColor != m_color){
            m_isChangeColor = true;
            var col = ps.colorOverLifetime;
            var main = ps.main;
            main.startColor = m_color;
            Gradient grad = new Gradient();
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(m_color, 1f) },
                            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 1.0f) });
            col.color = grad;
            childSphere.SetActive(true);
            m_colliderRadius = m_sphereCollider.radius;
            //m_Material.DOBlendableColor(m_color, 5).SetEase(Ease.OutSine);
            m_preColor = m_color;

        }
    }

    //あえて一瞬じゃなく0.5秒待機しています
    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        //childSphere.SetActive(false);
    }

    //

    /*
    Color ChangeESPColor{
        return
    }
    */
}
