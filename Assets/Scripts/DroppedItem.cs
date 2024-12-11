using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public QuestItem item;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
