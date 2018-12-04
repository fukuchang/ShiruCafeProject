using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubeScript : MonoBehaviour {

    //ある一定まで上に上がったら削除
    private void OnTriggerEnter(Collider col){
        if (col.tag == "ColorCube") {
            Destroy(col.gameObject);
        }
    }
}
