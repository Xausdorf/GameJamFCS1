using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Slider healthBar; // Перетащите сюда ваш Slider через Inspector
    public float maxHealth = 100f;
    public float currentHealth;
    public Image fillImage; // Укажите Image компонента Fill
    public PlayerHealth playerHealth;

    void Start()
    {
        if (playerHealth == null) playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        currentHealth = playerHealth.curHealth;
        healthBar.value = currentHealth / maxHealth * 100;
    }

    void Update()
    {
        if (playerHealth.curHealth == currentHealth) return;

        currentHealth = playerHealth.curHealth;
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth * 100;
            
            // Изменение цвета в зависимости от здоровья
            if (fillImage != null)
            {
                fillImage.color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);
            }
        }
    }
}