using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float movementX;
    private float movementY;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    public Animator anim;

    [SerializeField] private float speed = 10f;

    private int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        count = 0;
    }

    private void Update()
    {
        SetScoreText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * movementY ;
        float currentSpeed = playerRb.linearVelocity.magnitude;

        playerRb.AddForce(movement * speed);
        anim.SetFloat("Speed", currentSpeed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score : " + count;

        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
        }
    }


}
