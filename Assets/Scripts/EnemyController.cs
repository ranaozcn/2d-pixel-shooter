using UnityEngine;
public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator enemyAnimator;
    private Transform player;
    public float moveSpeed = 2f;
    public float patrolRange = 2f;
    private Vector2 targetPosition;
    private bool isMoving = false;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetNewTarget();
    }

    void Update()
    {
        FacePlayer();
        Patrol();
        UpdateAnimations();
    }

    void Patrol()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                Invoke("SetNewTarget", Random.Range(1f, 3f));
            }
        }
    }
    void FacePlayer()
    {
        if (player == null)
        {
            return;
        } 
        Vector3 direction = player.position - transform.position;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(7, 7, 1);
        }
        else
        {
            transform.localScale = new Vector3(-7, 7, 1);
        }
    }
    void SetNewTarget()
    {
        float randomX = Random.Range(transform.position.x - patrolRange, transform.position.x + patrolRange);
        targetPosition = new Vector2(randomX, transform.position.y);
        isMoving = true;
    }
    void UpdateAnimations()
    {
        float currentSpeed = Vector2.Distance(transform.position, targetPosition);
        enemyAnimator.SetFloat("Speed", currentSpeed);

        if (!enemyAnimator.GetBool("IsJumping") && Random.Range(0f, 3f) < 0.005f)
        {
            Jump();
        }
    }
    void Jump()
    {
        rigidBody2D.AddForce(Vector2.up * 300f);
        enemyAnimator.SetBool("IsJumping", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
        enemyAnimator.SetBool("IsJumping", false);
        }
    }

}
