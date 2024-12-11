using UnityEngine;

public class PlayerGrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform firePoint;
    public bool canThrow = true;
    public int remainEnergy = 100;
    public int energyBar = 0;

    void Start()
    {
        canThrow = true;
        energyBar = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canThrow)
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        Vector2 throwDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position).normalized;
        GameObject grenade = Instantiate(grenadePrefab, firePoint.position + (Vector3)throwDirection.normalized, Quaternion.identity);

        grenade.GetComponent<Grenade>().Throw(throwDirection);

        energyBar = Mathf.Max(0, energyBar - remainEnergy);
        if (energyBar <= 0)
        {
            canThrow = false;
        }
    }

    public void AddEnergy(int damage)
    {
        energyBar = Mathf.Min(energyBar + damage, remainEnergy);
        if (energyBar >= remainEnergy)
        {
            canThrow = true;
        }
    }
}
