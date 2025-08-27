using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    public float bulletSpeed = 3f;
    public float endTime = 1.7f;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        float direction = Mathf.Sign(transform.localScale.x);
        rigidBody2D.linearVelocity = Vector2.left * bulletSpeed * direction;
        Destroy(gameObject, endTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().GetDamage(10);
            Destroy(gameObject);
        }
    }
}
