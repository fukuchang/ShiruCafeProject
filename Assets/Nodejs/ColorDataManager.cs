using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataManager : MonoBehaviour
{

	public GameObject Receiver;
	private Receive _receive;
	//[SerializeField]
	//GameObject[] obj = new GameObject[16];
	public Color[] cols = new Color[16];
	//private Color[] matCol = new Color[16];
	void Start ()
	{
		_receive = Receiver.GetComponent < Receive >();
		//for(int i = 0; i < 16; i++)
		//{
		//	matCol[i] = obj[i].GetComponent < MeshRenderer >().material.color;
		//}
	}
	
	
	void Update () {
		for (int i = 0; i < 16; i++)
		{
			Debug.Log("-----i-value--------" + i);
			if (_receive.ColorDataArray[i] != null)
			{
				string[] c = _receive.ColorDataArray[i].Split(',');
				Debug.Log("---------length"+c.Length);
				if (c.Length == 3)
				{
                    Debug.Log(c[0] + "," + c[1] + "," + c[2] + "," + i.ToString());
                    cols[i] = new Color(float.Parse(c[0]) / 255.0f,
                                        float.Parse(c[1]) / 255.0f,
                                        float.Parse(c[2]) / 255.0f,
						1.0f);
					}
			}
		}
	}
}
