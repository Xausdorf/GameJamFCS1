using UnityEngine;
using UnityEngine.UI;

public class GrenadeCharge : MonoBehaviour
{
    public Slider chargeBar; // Перетащите сюда ваш Slider через Inspector
    public float maxCharge = 100f;
    public float currentCharge;
    public Image fillImage; // Укажите Image компонента Fill
    public PlayerGrenadeThrower grenadeThrower;

    void Start()
    {
        if (grenadeThrower == null) grenadeThrower = GameObject.Find("Player").GetComponent<PlayerGrenadeThrower>();
        currentCharge = grenadeThrower.energyBar;
        maxCharge = grenadeThrower.remainEnergy;
        chargeBar.value = 30 + currentCharge / maxCharge * 70;
    }

    void Update()
    {
        if (grenadeThrower == null) return;

        if (grenadeThrower.energyBar == currentCharge) return;

        currentCharge = grenadeThrower.energyBar;
        if (chargeBar != null)
        {
            chargeBar.value = 30 + currentCharge / maxCharge * 70;

            // Изменение цвета в зависимости от здоровья
            if (fillImage != null)
            {
                fillImage.color = Color.Lerp(Color.red, Color.green, currentCharge / maxCharge);
            }
        }
    }
}