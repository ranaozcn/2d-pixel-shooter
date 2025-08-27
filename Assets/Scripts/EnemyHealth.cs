using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public Image backGroundImage;
    public Image healthImage;

    public float maxHealth;
    public float currentHealth;
    private static int defeatedEnemies = 0;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (healthImage.fillAmount != backGroundImage.fillAmount)
        {
            backGroundImage.fillAmount = Mathf.Lerp(backGroundImage.fillAmount, healthImage.fillAmount, 0.01f);
        }
    }
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        healthImage.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            defeatedEnemies++;
            if (SceneManager.GetActiveScene().buildIndex == 3 && defeatedEnemies == 2) 
            {
                SceneManager.LoadScene(5);
            }
            else if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
