using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float leftBound;
    public float rightBound;
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (transform.position.x < leftBound)
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        else if (transform.position.x > rightBound)
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
    }
}