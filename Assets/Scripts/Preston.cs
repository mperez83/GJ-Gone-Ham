using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preston : MonoBehaviour
{
    public Vector2[] instructions;
    int stepNum;

    void Start()
    {
        StartCoroutine(PerformInstructions());
    }

    IEnumerator PerformInstructions()
    {
        while (true)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                yield return new WaitForSeconds(2);
                LeanTween.move(gameObject, new Vector2(transform.position.x, transform.position.y) + instructions[stepNum], 2).setEase(LeanTweenType.easeOutCubic);
            }
        }
    }
}