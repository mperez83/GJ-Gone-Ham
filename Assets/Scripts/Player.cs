using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 moveAmount;
        moveAmount.x = Input.GetAxisRaw("Horizontal") * speed;
        moveAmount.y = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = moveAmount;

        sr.sortingOrder = (int)transform.position.y * -1;
    }
}