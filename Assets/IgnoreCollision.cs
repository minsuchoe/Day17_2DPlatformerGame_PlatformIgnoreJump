using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {
    GameObject player;
    Transform foot;
    Color originalColor;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foot = player.transform.Find("rightFoot");
        originalColor = transform.parent.GetComponent<Renderer>().material.color;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlatformJumpTrigger")
            && player.GetComponent<PlayerController>().platformIgnoreJump)
        {
            if (foot.position.y < (transform.position.y + transform.localScale.y / 2.0f - 0.5f))
            //플랫폼의 윗면보다 플레이어 발의 y축이 밑에 있을 때
            {
                transform.parent.GetComponent<Renderer>().material.color = Color.white;
                foreach (var c in player.GetComponents<Collider2D>())
                    foreach (var g in transform.parent.GetComponents<Collider2D>()) 
                        Physics2D.IgnoreCollision(c, g, true);
            }
        }

        if (collision.CompareTag("PlatformJumpTrigger")
            && player.GetComponent<PlayerController>().platformIgnoreDown)
        {            
                foreach (var c in player.GetComponents<Collider2D>())
                    foreach (var g in transform.parent.GetComponents<Collider2D>())
                        Physics2D.IgnoreCollision(c, g, true);            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlatformJumpTrigger")
            && player.GetComponent<PlayerController>().platformIgnoreJump)
        {
            transform.parent.GetComponent<Renderer>().material.color = originalColor;
            foreach (var c in player.GetComponents<Collider2D>())
                foreach (var g in transform.parent.GetComponents<Collider2D>())
                    Physics2D.IgnoreCollision(c, g, false);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlatformJumpTrigger")
    //        && player.GetComponent<PlayerController>().platformIgnoreJump)
    //    {
    //        if (foot.position.y < (transform.position.y + transform.localScale.y / 2.0f - 0.5f))
    //            //플랫폼의 윗면보다 플레이어 발의 y축이 밑에 있을 때
    //        {
    //            transform.parent.GetComponent<Renderer>().material.color = Color.white;
    //            foreach (var g in transform.parent.GetComponents<Collider2D>())
    //                g.enabled = false;
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlatformJumpTrigger")
    //        && player.GetComponent<PlayerController>().platformIgnoreJump)
    //    {
    //        transform.parent.GetComponent<Renderer>().material.color = originalColor;
    //        foreach (var g in transform.parent.GetComponents<Collider2D>())
    //            g.enabled = true;
    //    }
    //}

}
