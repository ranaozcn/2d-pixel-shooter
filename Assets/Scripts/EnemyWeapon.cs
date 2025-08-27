using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float fireRateMin = 1f;
    public float fireRateMax = 3f;
    void Start()
    {
        InvokeRepeating("Shoot", Random.Range(fireRateMin, fireRateMax), Random.Range(fireRateMin, fireRateMax));
    }
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
