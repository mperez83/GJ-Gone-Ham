using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    int faceDir = 2;    //0 = Up, 1 = Right, 2 = Down, 3 = Left

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public Sprite[] left;
    public Sprite[] right;
    public Sprite[] up;
    public Sprite[] down;

   	int currentrunFrame = 0;
   	Sprite staticSprite;
   	[SerializeField] int fps;

   	float runFrameTime;
	float runFrameTimer = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        staticSprite = sr.sprite;
		runFrameTime = 1 / (float)fps;

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

        if (rb.velocity.x != 0 || rb.velocity.y != 0) {
            if (runFrameTimer < runFrameTime) {
                runFrameTimer += Time.deltaTime;
            }
            else if (rb.velocity.y < 0) {
                sr.sprite = down[currentrunFrame];
                currentrunFrame = (currentrunFrame + 1) % (up.Length);
                runFrameTimer = 0;
            }
            else if (rb.velocity.x < 0) {
                sr.sprite = left[currentrunFrame];
                currentrunFrame = (currentrunFrame + 1) % (left.Length);
                runFrameTimer = 0;
			}
			else if (rb.velocity.x > 0) {
				sr.sprite = right[currentrunFrame];
                currentrunFrame = (currentrunFrame + 1) % (right.Length);
                runFrameTimer = 0;
			}
            else if (rb.velocity.y > 0) {					
                sr.sprite = up[currentrunFrame];
                currentrunFrame = (currentrunFrame + 1) % (down.Length);
                runFrameTimer = 0;
            }   
        }
        else {
            sr.sprite = staticSprite;
        }

		




    }



}