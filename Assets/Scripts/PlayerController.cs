using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 0, 2000 * Time.deltaTime);
        score = 0;
        health = 5;
        scene =  SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(1000 * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-1000 * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 1000 * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -1000 * Time.deltaTime * speed);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            //Debug.Log("Score: " + score);
            SetScoreText();
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
    public Rigidbody rb;
    public float speed;
    private int score;
    public int health;
    private Scene scene;
    public Text scoreText;
}
