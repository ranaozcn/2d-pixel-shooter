using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Vector3 velocity;
    Animator playerAnimator;
    public float moveSpeed;
    bool facingRight = true;
    public float jumpSpeed;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();
        if (velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        if (velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rigidBody2D.linearVelocity.y, 0))
        {
            rigidBody2D.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            playerAnimator.SetBool("IsJumping", true);
        }
        if (playerAnimator.GetBool("IsJumping") && Mathf.Approximately(rigidBody2D.linearVelocity.y, 0))
        {
            playerAnimator.SetBool("IsJumping", false);
        }
    }

    void HorizontalMove()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * moveSpeed * Time.deltaTime;
        playerAnimator.SetFloat("Speed", Math.Abs(velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
