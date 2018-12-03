using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Spawn(){
        while(true){
            
            yield return new WaitForSeconds(Random.Range(1.0f, 5.0f));
            GameObject instance = Instantiate(Resources.Load("subCube", typeof(GameObject)),
                                              new Vector3(Random.Range(-10f, 10f),
                                                          transform.position.y, 
                                                          Random.Range(-10f, 10f)), 
                                              transform.rotation) as GameObject;
            instance.transform.parent = this.transform;
        }
    }
}
