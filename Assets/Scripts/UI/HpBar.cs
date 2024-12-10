using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Slider healthBar; // Перетащите сюда ваш Slider через Inspector
    public float maxHealth = 100f;
    private float currentHealth;
    public Image fillImage; // Укажите Image компонента Fill

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
            
            // Изменение цвета в зависимости от здоровья
            if (fillImage != null)
            {
                fillImage.color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);
            }
        }
    }
}