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
    bool pacified;

    void Start()
    {
        anchorPos = transform.position;
    }

    void Update()
    {
        deg += stumbleSpeed * Time.deltaTime;
        if (deg >= 720) deg -= 720;

        float finalSinX = horizontalStumbleDistance * Mathf.Sin(deg * Mathf.Deg2Rad);
        float finalSinY = verticalStumbleDistance * Mathf.Sin(0.5f * deg * Mathf.Deg2Rad);
        transform.position = new Vector3(anchorPos.x + finalSinX, anchorPos.y + finalSinY, transform.localPosition.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!pacified)
            {
                GameMaster.instance.AddTime(20);
                pacified = true;
            }
        }
    }
}