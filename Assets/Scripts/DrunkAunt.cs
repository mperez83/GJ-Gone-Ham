using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkAunt : MonoBehaviour
{
    float deg;
    public float stumbleSpeed = 100;
    public float verticalStumbleDistance = 1;
    public float horizontalStumbleDistance = 1;
    Vector2 anchorPos;
    Vector2 prevPos;
    bool pacified;

    Animator anim;
    SpriteRenderer sr;
    Player player;
    Fungus.Flowchart fChart;


    void Start()
    {
        anchorPos = transform.position;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        fChart = GetComponent<Fungus.Flowchart>();
    }

    void Update()
    {
        prevPos = transform.position;

        deg += stumbleSpeed * Time.deltaTime;
        if (deg >= 720) deg -= 720;

        float finalSinX = horizontalStumbleDistance * Mathf.Sin(deg * Mathf.Deg2Rad);
        float finalSinY = verticalStumbleDistance * Mathf.Sin(0.5f * deg * Mathf.Deg2Rad);
        transform.position = new Vector3(anchorPos.x + finalSinX, anchorPos.y + finalSinY, transform.localPosition.z);

        anim.SetFloat("yVelocity", (transform.position.y - prevPos.y));

        sr.sortingOrder = (int)transform.position.y * -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!pacified)
            {
                pacified = true;
                player.canMove = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                fChart.ExecuteBlock("Ramble");
            }
        }
    }
}