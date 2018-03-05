using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCoin : MonoBehaviour {
    public float speed = 0.5f;
    public float dir = 1.0f;
    public float min;

	// Use this for initialization
	void Start () {
        min = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        float y = transform.position.y;

        if (y > min + 0.25f)
            dir = -1.0f;
        if (y < min)
            dir = 1.0f;

        transform.Translate(0f, dir * Time.deltaTime * speed, 0f);
    }
}
