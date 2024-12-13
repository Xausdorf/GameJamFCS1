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

    public GameObject Spawn(Vector3 position)
    {
        return Instantiate(observerPrefab, position, Quaternion.identity);
    }
}
