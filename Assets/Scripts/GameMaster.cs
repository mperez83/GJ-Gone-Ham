using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    float timeSpent;

    void Start()
    {

    }

    void Update()
    {
        timeSpent += Time.deltaTime;
    }
}