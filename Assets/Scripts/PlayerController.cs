using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 10.0f;

    Vector3 movement;
    int score = 0;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI healthText;
    int health = 10;
    //TextMeshProUGUI timer;
    public float jumpSpeed = 10.0f;
    public bool isGrounded = false;
    public bool canDoubleJump = false;
    float rotateSpeed = 20.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        UpdateHealth(0);
        //timer = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //timer.text = Time.time.ToString("F2");
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Input.GetAxis("Mouse X") * rotateSpeed * Vector3.up);
        }
        movement = transform.TransformDirection(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true) { 
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            } 
            else if(canDoubleJump == true)
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                canDoubleJump = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed + new Vector3(0, rb.velocity.y, 0);
    }

    private void LateUpdate()
    {
        if (transform.rotation.y != Camera.main.transform.rotation.y)
        {
            Quaternion angle =
            Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up);
            transform.rotation = angle;
        }
    }

    public void AwardPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int damage)
    {
        health += damage;
        healthText.text = "Health: " + health;
        if (isDead())
        {
            GameObject.Find("RespawnPoint").GetComponent<GameController>().GameOverSequence();
        }
    }

    public bool isDead()
    {
        return health <= 0 ? true : false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            canDoubleJump = true;
        }
    }


}
