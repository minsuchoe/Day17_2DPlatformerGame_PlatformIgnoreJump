using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlatformJumpTrigger"))
            collision.gameObject.transform.parent.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlatformJumpTrigger"))
            collision.gameObject.transform.parent.transform.parent = null;
    }
}
