using UnityEngine;
using UnityEngine.UI;

public class GranadeCharge : MonoBehaviour
{
    public Slider chargeBar; // Перетащите сюда ваш Slider через Inspector
    public float maxCharge = 100f;
    public float minCharge = 0f;
    private float currentCharge;
    public Image fillImage; // Укажите Image компонента Fill

    void Start()
    {
        currentCharge = minCharge;
        UpdateHealthBar();
    }

    public void GranateUsage()
    {
        currentCharge = 0;
        UpdateHealthBar();
    }

    public void AddCharge(float chargeAmount)
    {
        currentCharge += chargeAmount;
        currentCharge = Mathf.Clamp(currentCharge, minCharge, maxCharge);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (chargeBar != null)
        {
            chargeBar.value = currentCharge / maxCharge;
            
            // Изменение цвета в зависимости от здоровья
            if (fillImage != null)
            {
                fillImage.color = Color.Lerp(Color.yellow, Color.green, currentCharge / maxCharge);
            }
        }
    }
}