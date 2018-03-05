using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {
    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin = 7.4f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax= 6f;

    Vector2 originaPosition;

    // Use this for initialization
    void Start () {
        originaPosition = transform.position;
        Spawn();
	}

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originaPosition
                + new Vector2(Random.Range(horizontalMin, horizontalMax),
                Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originaPosition = randomPosition;
        }
    }

}
