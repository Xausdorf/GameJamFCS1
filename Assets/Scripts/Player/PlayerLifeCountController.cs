using UnityEngine;

public class PlayerLifeCountController : MonoBehaviour
{
    public int maxLifeCount = 3;
    public int curLifeCount = 0;
    public Vector3 spawnPoint = new Vector3(3, 3, 0);
    public GameObject player;
    public float resurrectionCooldown = 3f;
    private PlayerController playerController;
    private bool isDead = false;

    void Start()
    {
        isDead = false;
        maxLifeCount = 3;
        curLifeCount = maxLifeCount;
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        playerController = player.GetComponent<PlayerController>();
    }

    public void Die()
    {
        if (isDead) return;

        curLifeCount--;
        isDead = true;
        spawnPoint = transform.position + 2 * Vector3.up;
        if (curLifeCount <= 0)
        {
            Destroy(player);
        }
        else
        {
            player.SetActive(false);
            Invoke(nameof(Resurrect), resurrectionCooldown);
        }
    }

    private void Resurrect()
    {
        isDead = false;
        player.SetActive(true);

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.curHealth = playerHealth.maxHealth;

        player.transform.position = spawnPoint;
    }
}
