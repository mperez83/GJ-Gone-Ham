using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mother : MonoBehaviour
{
    public float yVel;

    public GameObject player;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, yVel);
    }

    void Update()
    {
        //Set X position to player's X position every frame
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        //transform.Translate(Vector2.up * yVel * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Mother Ending");
        }
    }
}