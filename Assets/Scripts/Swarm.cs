using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    public float zipTimerMinLength;
    public float zipTimerMaxLength;
    float zipTimer;
    bool onLeftSide = true;
    bool pacified;

    SpriteRenderer sr;

    void Start()
    {
        zipTimer = Random.Range(zipTimerMinLength, zipTimerMaxLength);
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        zipTimer -= Time.deltaTime;
        if (zipTimer <= 0)
        {
            zipTimer += Random.Range(zipTimerMinLength, zipTimerMaxLength);
            if (onLeftSide)
                LeanTween.moveX(gameObject, 20, 2.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => { sr.flipX = !sr.flipX; });
            else
                LeanTween.moveX(gameObject, -20, 2.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => { sr.flipX = !sr.flipX; }); ;
            onLeftSide = !onLeftSide;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!pacified)
            {
                GameMaster.instance.AddTime(5);
                pacified = true;
            }
        }
    }
}