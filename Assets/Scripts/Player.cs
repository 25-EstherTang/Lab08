﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float Score;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if (transform.position.y < -3)
        {
            transform.position = new Vector3(transform.position.x, -3f, transform.position.z);
        }

        else if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "Obstacle")
            {
                SceneManager.LoadScene("GameOverScene");
            }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            Score++;
            scoreText.GetComponent<Text>().text = "Score: " + Score;
        }
    }
}
