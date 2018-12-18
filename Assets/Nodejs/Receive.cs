using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

public class Receive : MonoBehaviour
{
	public string _serverAddress;
	[SerializeField] private int _port;
	private WebSocket ws;
	public string[] ColorDataArray = new string[16];
	void Start ()
	{
		StartCoroutine(Sample());
	}


	void Update()
	{
	}

	
	private IEnumerator Sample() {  
		var ca = "ws://" + _serverAddress + ":" + _port.ToString();
		this.ws = new WebSocket(ca);

		// WebSocketをOpen.
		this.ws.OnOpen += (sender, e) => 
		{
			Debug.Log("[WS] Open");
			ws.Send ("Hi WebSocket");
		};

		// メッセージを受信.
		this.ws.OnMessage += (sender, e) =>
		{
			Debug.Log(e.Data);
			var temp = e.Data.Split('\n');
			Debug.Log(temp.Length);
			
			//tempにr,g,bの形式で値が格納されている
			for (var i = 0; i < temp.Length; i++)
			{
				
				var deleteStr = "value" + (i + 1).ToString() + " : ";
				temp[i] = temp[i].Replace(deleteStr, "");
				//Debug.Log(i.ToString() + " : " + temp[i]);
				ColorDataArray[i] = temp[i]; //他ファイルからアクセスできるようにしておく
			}

		};
		this.ws.Connect();
		yield return new WaitForSeconds (2.0f);
		StartCoroutine(Sample());
		yield return null;

	}  
}
