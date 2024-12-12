using UnityEngine;

public class ObserverSpawner : MonoBehaviour
{
    public GameObject observerPrefab;
    public static ObserverSpawner instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnPresent(Vector3 position)
    {
        Instantiate(observerPrefab, position, Quaternion.identity);
    }
}
