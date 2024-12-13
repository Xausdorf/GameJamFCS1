using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(QuestItem item) => AddItem(item, 1);

    public void AddItem(QuestItem item, int amount)
    {
        if (!items.ContainsKey(item.itemName))
        {
            items[item.itemName] = amount;
        } else
        {
            items[item.itemName] += amount;
        }
    }

    public void RemoveItem(string itemName) => RemoveItem(itemName, 1);

    public void RemoveItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] = Mathf.Max(items[itemName] - amount, 0);
        }
    }

    public int GetItemCount(string itemName) => items.ContainsKey(itemName) ? items[itemName] : 0;
}
