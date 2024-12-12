using Pathfinding;
using UI;
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
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private bool isLeft;
    public float tenseCooldown = 15f;
    public int tense = 2;
    public int enemyCount = default;
    private float timeUntilSpawn = default;
    private float timeUntilTenseInc;
    private int nextEnemy;


    // Start is called before the first frame update
    void Start()
    {
        timeUntilSpawn = 10 / tense;
        timeUntilTenseInc = 0;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        timeUntilTenseInc += Time.deltaTime;
        if (isLeft)
        {
            Spawner.transform.position = new Vector2(Player.transform.position.x - 20, Player.transform.position.y);
        }
        else
        {
            Spawner.transform.position = new Vector2(Player.transform.position.x + 20, Player.transform.position.y);
        }
        timeUntilSpawn -= Time.deltaTime;
        if ((timeUntilSpawn < 0) && (enemyCount < tense))
        {
            nextEnemy = Random.Range(0, 100);
            enemyCount++;
            GameObject spawned;
            if (nextEnemy <= 70)
            {
                spawned = Instantiate(SpawnerShooter, transform.position, Quaternion.identity);
                spawned.GetComponent<EnemyHealth>().spawner = this;
            }
            else
            {
                if (nextEnemy <= 90)
                {
                    spawned = Instantiate(SpawnerShotgunner, transform.position, Quaternion.identity);
                    spawned.GetComponent<EnemyHealth>().spawner = this;
                }
                else
                {
                    spawned = Instantiate(SpawnerBomber, transform.position, Quaternion.identity);
                    spawned.GetComponent<EnemyHealth>().spawner = this;
                }
            }
            spawned.GetComponent<AIDestinationSetter>().target = Player.transform;
            timeUntilSpawnSet();
        }
        if (timeUntilTenseInc >= tenseCooldown)
        {
            timeUntilTenseInc = 0;
            tense++;
        }
    }
    private void timeUntilSpawnSet()
    {
        timeUntilSpawn = 10 / tense;
    }
}
