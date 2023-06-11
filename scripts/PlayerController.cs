using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;  // Player'ın hareket hızı
    AudioSource source;
    private bool isMoving;

    public float timeBetweenSteps;
    float timer;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Horizontal hareket (Sol-sağ ok tuşları veya A-D tuşları ile hareket)
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = transform.right * horizontalInput * speed * Time.deltaTime;
        transform.position += horizontalMovement;

        // Vertical hareket (Yukarı-aşağı ok tuşları veya W-S tuşları ile hareket)
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 verticalMovement = transform.forward * verticalInput * speed * Time.deltaTime;
        transform.position += verticalMovement;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeBetweenSteps;
                source.pitch = Random.Range(0.85f, 1.15f);

                source.Play(); // Play the audio clip
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag($"Enemy"))
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void Dead()
    {
        Debug.Log("ay xiyar");
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!isMoving)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeBetweenSteps;
                source.Play(); // Play the audio clip
            }
        }
    }
}
