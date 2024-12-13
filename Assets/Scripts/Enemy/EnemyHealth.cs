using UnityEngine;

public class EnemyHealth : Health
{
    public QuestManager questManager;
    public PlayerGrenadeThrower grenadeThrower;
    public EnemySpawner spawner;
    public AudioSource audioSource;

    protected override void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        grenadeThrower = GameObject.Find("Player").GetComponent<PlayerGrenadeThrower>();
        audioSource = GetComponent<AudioSource>();
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        curHealth -= damage;

        if (grenadeThrower != null)
        {
            grenadeThrower.AddEnergy(damage);
            if (curHealth < 0)
            {
                grenadeThrower.AddEnergy(curHealth);
            }
        }

        if (curHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        // Debug.Log(questManager.Levels[curQuest].objectives[cur].Type);
        if (questManager.Levels[curQuest].objectives[cur].Type == 1) {
            if (Random.Range(0f, 1f) <= 0.5f) {
                PresentSpawner.instance.SpawnPresent(transform.position);
            }
        }
        if (spawner != null)
        {
            spawner.enemyCount--;
        }

        if (audioSource != null) audioSource.Play();

        Destroy(gameObject);
    }
}
