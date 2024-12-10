using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponBase> weapons;
    public int curWeapon = 0;

    void Start()
    {
        weapons = new List<WeaponBase>();
        foreach (Transform weapon in transform)
        {
            weapons.Add(weapon.gameObject.GetComponent<WeaponBase>());
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].Activate(i == curWeapon);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToIndex((curWeapon + 1) % weapons.Count);
        }
    }

    private void SwitchToIndex(int newIndex)
    {
        weapons[curWeapon].Activate(false);
        weapons[newIndex].Activate(true);
        curWeapon = newIndex;
    }
}
