using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour {

    public float min;
    public float shakingSpeed = 5.0f;
    public float fallingSpeed = 0.1f;
    public float dir = 1.0f;
    bool isShaking = true;
    bool isFalling = true;
    bool isColliding = true;

    void Start()
    {
        min = transform.position.x;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ShakingPlatform");
        }
    }

    IEnumerator ShakingPlatform()
    {
        if (!isColliding)
            yield break;
        isColliding = false;

        float x = transform.position.x;

        while (isShaking)
        {
            //print("min : " + min); print("x : " + x);

            if (x > min + 0.25f)            
                dir = -1.0f;
                            
            if (x < min)
                dir = 1.0f;
            
            x = transform.position.x;

            transform.Translate(dir * Time.deltaTime * shakingSpeed, 0f, 0f);

            Invoke("ShakeEnd", 2);
            
            yield return null;
        }
        StartCoroutine(FallingDownPlatform());
        yield return new WaitForSeconds(0.1f);        
    }

    void ShakeEnd()
    {
        isShaking = false;
    }

    IEnumerator FallingDownPlatform()
    {
        float y = transform.position.y;

        while (isFalling)
        {
            transform.Translate(0f, Time.deltaTime * fallingSpeed * -1.0f, 0f);
            fallingSpeed += 0.2f;
            yield return null;
        }        
    }
}
