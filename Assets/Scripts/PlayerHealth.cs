using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image backGroundImage;
    public Image healthImage;

    public float maxHealth;
    float currentHealth;
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
            SceneManager.LoadScene(4);
        }
    }
}
