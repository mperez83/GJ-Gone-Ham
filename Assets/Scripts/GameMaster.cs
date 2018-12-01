using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    float timeSpent;
    int displayTime;

    public Text timerText;



    void Start()
    {

    }

    void Update()
    {
        timeSpent += Time.deltaTime;
        displayTime = (int)Mathf.Floor(timeSpent);
        timerText.text = displayTime.ToString();
        timerText.fontSize = 12 + (int)Mathf.Floor(displayTime * 0.1f);
    }
}