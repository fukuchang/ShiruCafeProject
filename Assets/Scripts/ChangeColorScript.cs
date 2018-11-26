using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour {

    Material m_Material;
    public Color m_color;

	// Use this for initialization
	void Start () {
        m_Material = this.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        m_Material.color = m_color;
	}
}
