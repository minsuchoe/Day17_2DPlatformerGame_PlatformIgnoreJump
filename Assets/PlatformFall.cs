using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {
    public float fallDelay = 3f;

    //Rigidbody2D rb;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    rb.isKinematic = true;
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke("Fall", fallDelay);
    }

    void Fall()
    {
        if (GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>(); //as Rigidbody2D; 없어도 상관 없다.
            if (rb != null)
                rb.isKinematic = false;
            //rb.isKinematic = false;        
        }
    }
}
