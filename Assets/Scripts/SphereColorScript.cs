using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereColorScript : MonoBehaviour {

    public Color m_color; //変更される色(espから受け取られる色)
    public bool m_isChangeColor = false; //色が変わったかどうかの真偽値
    public float m_colliderRadius; //色を変えるCubeを認識どこまで認識するか(Colliderの半径)
    public string keyword; //Test Code キーボード用の文字

    Material m_Material;
    Color m_preColor; //変わる前の色
    GameObject childSphere;
    SphereCollider m_sphereCollider;

	void Awake () {
        m_Material = this.GetComponent<Renderer>().material;
        m_preColor = m_color;
        childSphere = gameObject.transform.Find("Sphere").gameObject;
        m_sphereCollider = childSphere.GetComponent<SphereCollider>();
    }

	void Update () {
        
        if(m_isChangeColor){
            m_isChangeColor = false;
            StartCoroutine("Wait");
        }

        //Test Code
        if (Input.GetKeyDown(keyword))
        {
            m_color = Test_ChangeRndColor();
        }
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
        return testColor;
    }
    //

    /*
    Color ChangeESPColor{
        return
    }
    */
}
