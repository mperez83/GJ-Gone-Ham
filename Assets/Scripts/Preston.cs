using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preston : MonoBehaviour
{
    Vector2 startPos;
    public Vector2[] instructions;
    [HideInInspector]
    public bool pacified;
    SpriteRenderer sr;
    Fungus.Flowchart fChart;
    Player player;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(PerformInstructions());
        sr = GetComponent<SpriteRenderer>();
        fChart = GetComponent<Fungus.Flowchart>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        sr.sortingOrder = (int)transform.position.y * -1;
    }

    IEnumerator PerformInstructions()
    {
        while (true)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                yield return new WaitForSeconds(3);
                LeanTween.move(gameObject, new Vector2(transform.position.x, transform.position.y) + instructions[i], 1).setEase(LeanTweenType.easeOutCubic);
            }

            yield return new WaitForSeconds(3);
            LeanTween.move(gameObject, startPos, 1).setEase(LeanTweenType.easeOutCubic);
        }
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
                fChart.ExecuteBlock("Brag");
            }
        }
    }
}