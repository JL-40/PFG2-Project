using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    // Update is called once per frame
    void Update()
    {
        useWeapon.ShootGun.performed += ctx => Shoot();
    }
}
