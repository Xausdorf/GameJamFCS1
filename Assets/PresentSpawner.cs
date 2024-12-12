using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSpawner : MonoBehaviour
{
    public GameObject presentPrefab;
    public static PresentSpawner instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void SpawnPresent(Vector3 position) {
        Instantiate(presentPrefab, position, Quaternion.identity);
    }
}
