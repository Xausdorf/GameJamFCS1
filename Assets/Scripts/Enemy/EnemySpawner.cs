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
    TimerUI timer = GameObject.Find("TimerText").GetComponent<TimerUI>();
    public int tense = 2;
    private int enemyCount = default;
    private float timeUntilSpawn = default;
    private int nextEnemy;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilSpawn = 10 / tense;
    }

    // Update is called once per frame
    private void Update()
    {
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
            if (nextEnemy <= 70)
            {
                Instantiate(SpawnerShooter, transform.position, Quaternion.identity);
            }
            else
            {
                if (nextEnemy <= 90)
                {
                    Instantiate(SpawnerShotgunner, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(SpawnerBomber, transform.position, Quaternion.identity);
                }
            }
            timeUntilSpawnSet();
        }
        if (timer.totalTime % 15 == 0)
        {
            tense++; // почините :(((
        }
    }
    private void timeUntilSpawnSet()
    {
        timeUntilSpawn = 10 / tense;
    }
}
