using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DinnerTable : MonoBehaviour
{
    public Image fadeToWhite;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            LeanTween.value(gameObject, 0, 1, 6).setIgnoreTimeScale(true).setOnUpdate((float value) =>
            {
                fadeToWhite.color = new Color(fadeToWhite.color.r, fadeToWhite.color.g, fadeToWhite.color.b, value);
            }).setOnComplete(() =>
            {
                LeanTween.delayedCall(gameObject, 1, () => { SceneManager.LoadScene("Good Ending"); }).setIgnoreTimeScale(true);
            });
        }
    }
}