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

    public GameObject buttons;
    public AudioSource audioSource;
    public AudioClip winAudio;
    public AudioClip loseAudio;
    public AudioClip pickupAudio;

    public Animator anim;

    [SerializeField] private float speed = 100f;

    public FootstepController footstepController;

    private int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        footstepController = GetComponent<FootstepController>();
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

        if (movementY != 0 && currentSpeed > 0.1f)
        {
            footstepController.PlayFootStep();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(pickupAudio);
            count++;
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score : " + count;

        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            buttons.gameObject.SetActive(true);
            audioSource.PlayOneShot(winAudio);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winText.gameObject.SetActive(true);
            buttons.gameObject .SetActive(true);
            audioSource.PlayOneShot(loseAudio);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
        }
    }


}
