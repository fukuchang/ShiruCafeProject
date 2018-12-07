using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubeScript : MonoBehaviour {

    public float m_range = 15f;
    string spawnName;

	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn");
	}

    private IEnumerator Spawn(){
        while(true){
            Vector3 spawnPos = transform.position;
            int spawnNum = Random.Range(1, 10);
            int extra = spawnNum % 2;
            switch (extra)
            {
                case 0:
                    spawnName = "LantanumA";
                    break;
                case 1:
                    spawnName = "LantanumB";
                    break;
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 3.0f));
            GameObject instance = Instantiate(Resources.Load(spawnName, typeof(GameObject)),
                                              new Vector3(Random.Range(spawnPos.x - m_range, spawnPos.x + m_range),
                                                          spawnPos.y, 
                                                          Random.Range(spawnPos.z - m_range, spawnPos.z + m_range)), 
                                              Quaternion.identity) as GameObject;
            instance.transform.parent = this.transform;
        }

    }
}
