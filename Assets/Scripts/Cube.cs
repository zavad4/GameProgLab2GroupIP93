using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float jumpForce = 1.0f;
    Rigidbody player;
    Vector3 movement;
    bool isOnTheGround;
    private PointsManager pointsManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        pointsManager = FindObjectOfType<PointsManager>();
        isOnTheGround = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            movement.x = moveSpeed * Input.GetAxis("Horizontal");
            player.velocity = movement;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            movement.z = moveSpeed * Input.GetAxis("Vertical");
            player.velocity = movement;
        }

        if (Input.GetKey(KeyCode.Space) && isOnTheGround)
        {
            player.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            pointsManager.AddPoint();
        }
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnTheGround = false;
        }
    }
}
