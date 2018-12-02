using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    int faceDir = 2;    //0 = Up, 1 = Right, 2 = Down, 3 = Left

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveAmount;
        moveAmount.x = Input.GetAxisRaw("Horizontal") * speed;
        moveAmount.y = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = moveAmount;

        //Set direction animator variable
        /*if (rb.velocity.y > 0)
        {
            faceDir = 0;
        }
        else
        {
            faceDir = 2;
            if (rb.velocity.x > 0) faceDir = 1;
            else if (rb.velocity.x < 0) faceDir = 3;
        }
        anim.SetInteger("Direction", faceDir);

        //Set moving animator variable
        if (rb.velocity.x != 0 && rb.velocity.y != 0)
            anim.SetBool("Moving", true);
        else
            anim.SetBool("Moving", false);*/

        sr.sortingOrder = (int)transform.position.y * -1;
    }
}