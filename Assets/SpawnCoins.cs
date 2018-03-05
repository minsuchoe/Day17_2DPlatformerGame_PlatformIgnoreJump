using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {
    public Transform[] coinSpawns;
    public GameObject coin;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Spawn () {
		for (int i = 0; i < coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);  // (int타입) 0부터 '1'까지
            if (coinFlip > 0)
            {
                var clone = Instantiate(coin, coinSpawns[i].position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
                //Instantiate(coin, coinSpawns[i].position, Quaternion.identity);
                if (Random.Range(0, 100) > 70)  // 30% 확률
                    clone.transform.localScale = clone.transform.localScale * 1.5f;
            }                
        }
	}
}
