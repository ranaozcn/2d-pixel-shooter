using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    public float endTime;
    public float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * bulletSpeed;
        Destroy(gameObject, endTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().GetDamage(damage);
            Destroy(gameObject);
        }
    }  

}
