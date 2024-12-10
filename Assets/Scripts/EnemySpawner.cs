using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour

{
    [SerializeField]
    private GameObject SpawnerShooter;
    [SerializeField]
    private GameObject SpawnerShotgunner;
    [SerializeField]
    private GameObject SpawnerBomber;
    [SerializeField]
    private GameObject Spawner;

    int tense = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(SpawnerShooter, 10 / tense));
        StartCoroutine(spawnEnemy(SpawnerShotgunner, 10 / tense));
        StartCoroutine(spawnEnemy(SpawnerBomber, 10 / tense));
    }

    // Update is called once per frame

    private IEnumerator spawnEnemy(GameObject enemy, float interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position[0], transform.position[1]), Quaternion.identity);
        StartCoroutine(spawnEnemy(enemy, interval));
    }
}
