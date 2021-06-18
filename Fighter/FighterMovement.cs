using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    public float speed;

    public float fallMulti = 2.5f;
    public float jumpVelocity = 5;
    public float lowJump = 2;

    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;

    private GameObject otherPlayer;
    private FighterControl cont;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cont = GetComponent<FighterControl>();
    }

    //runs every Frame?
    void Update()
    { 
        PlayerMovement();
        JumpCheck();
        CrouchCheck();
    }

    //runs every Physics update
    void FixedUpdate()
    {
        PerformMove();
    }

    void PlayerMovement()
    {
        float hori = Input.GetAxisRaw("Horizontal");

        Vector2 mHori = transform.right * hori;

        Vector2 add_v = mHori.normalized * speed;
        //final movement
        if((Input.GetKey(KeyCode.S) && !cont.GetJumping()) || cont.GetJumping())
        {
            add_v = new Vector2(0, 0);
        }
        if(!cont.GetJumping())
            move(add_v);
    }

    //gets movement vector
    void move(Vector2 add_v)
    {
        velocity = add_v;
    }

    void PerformMove()
    {
        if (velocity != Vector2.zero && !cont.GetJumping())
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void JumpCheck()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && !cont.GetJumping())
        {
            rb.velocity = new Vector2(velocity.x, 1 * jumpVelocity);
            cont.JumpAni();
            cont.SetJumping(true);
        }
    }

    void CrouchCheck()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && !cont.GetJumping() && !cont.GetAttacking())
        {
            cont.CrouchingAni();
        }
        else if(cont.GetCrouch())
        {
            cont.UnCrouchingAni();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Wall"))
        {
            //kill horizontal movement
            Vector3 mHori = transform.right * 0;
            Vector3 add_v = mHori.normalized * speed;
            move(add_v);
        }

        if (collision.collider.tag.Equals("Floor"))
        {
            cont.SetJumping(false);
            cont.playStandIdle();
        }
    }
}
