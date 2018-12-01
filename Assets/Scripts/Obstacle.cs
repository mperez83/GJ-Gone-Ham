using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y * -1;
    }
}