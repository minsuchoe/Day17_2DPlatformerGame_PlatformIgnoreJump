using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool facingRight = true;
    public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public bool platformIgnoreJump = false;
    public bool platformIgnoreDown = false;

    bool grounded = false;
    Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        // 0000 1000 0000 0000 == 1 << 11 : 1을 11번 비트 시프트
        // 0000 1100 0000 0000 == 1 << 11 | 1 << 10
        // 0001 0000 0000 0000 == 1 << 12
        // 0001 1000 0000 0000 == 1 << 12 | 1 << 11

        //grounded = Physics2D.Linecast(transform.position,
        //                              groundCheck.position,
        //                              1 << LayerMask.NameToLayer("Ground"));    //Ground의 Layer Index는 12


        RaycastHit2D hit = Physics2D.Linecast(transform.position,
                                              groundCheck.position,
                                              10000);
                                              //1 << LayerMask.NameToLayer("Ground"));
        grounded = hit.collider != null;

        if (Input.GetButtonDown("Jump") && grounded && !anim.GetBool("Jump"))
            jump = true;

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetButton("Jump"))
        {
            platformIgnoreDown = true;
        }
        else
        {
            platformIgnoreDown = false;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));       // Mathf.Abs : 절대값

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (Input.GetKey(KeyCode.DownArrow))
            jump = false;

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;            
        }       

        if (platformIgnoreJump)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
                                           LayerMask.NameToLayer("Ground"),
                                           rb.velocity.y > 0);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
