using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preston : MonoBehaviour
{
    Vector2 startPos;
    public Vector2[] instructions;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(PerformInstructions());
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
}