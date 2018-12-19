using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereColorScript : MonoBehaviour {

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


	void Awake () {
        m_Material = this.GetComponent<Renderer>().material;
        childSphere = gameObject.transform.Find("Sphere").gameObject;
        m_sphereCollider = childSphere.GetComponent<SphereCollider>();
        CDM = System.gameObject.GetComponent<ColorDataManager>();
        m_preColor = CDM.cols[m_Num];
    }

	void Update () {
        
        if(m_isChangeColor){
            m_isChangeColor = false;
            StartCoroutine("Wait");
        }

        if(m_preColor != CDM.cols[m_Num]){
            m_color = CDM.cols[m_Num];
            Debug.Log(m_color);
        }

        //Test Code
        //if (Input.GetKeyDown(keyword))
        //{
        //    m_color = Test_ChangeRndColor();
        //    //m_color = LeastColor(m_color);
        //    if (m_color.r > m_color.g && m_color.g > m_color.b)
        //    {
        //        m_color.b = 0;
        //    }
        //    else if (m_color.g > m_color.b && m_color.b > m_color.r)
        //    {
        //        m_color.r = 0;
        //    }
        //    else if (m_color.b > m_color.r && m_color.r > m_color.g)
        //    {
        //        m_color.b = 0;
        //    }
        //}
        //

        //--- ここにespで取得したカラー値を入れる
        /*
         * m_color = ChangeESPColor();
        */


        if(m_preColor != m_color){
            m_isChangeColor = true;
            //childSphere.SetActive(true);
            m_colliderRadius = m_sphereCollider.radius;
            m_Material.DOBlendableColor(m_color, 5).SetEase(Ease.OutSine);
            m_preColor = m_color;

        }
	}

    //あえて一瞬じゃなく0.5秒待機しています
    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        //childSphere.SetActive(false);
    }

    //Test Code
    Color Test_ChangeRndColor(){
        Color testColor;
        testColor.r = Random.Range(0f, 1f);
        testColor.g = Random.Range(0f, 1f);
        testColor.b = Random.Range(0f, 1f);
        testColor.a = 1f;

        float color_r = testColor.r;
        float color_g = testColor.g;
        float color_b = testColor.b;
        return testColor;
    }

    //

    /*
    Color ChangeESPColor{
        return
    }
    */
}
