using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AmmoType
{
    Single,
    Pellet
}

public abstract class Gun : MonoBehaviour
{
    protected int magazineAmmoCount;  // How much ammo is in the gun's magazine.
    protected int reserveAmmoCount;   // How much ammo the gun has to reload from.
    protected AmmoType cartridge;     // The type of ammo the gun uses (Single bullet or a pellet of multiple bullets.
    protected int pelletCount = 0;    // The amount of pellets the gun shoots.

    //
    protected float damage;   // The damage the gun does.
    protected float rateOfFire;   // How fast the gun can shoot.
    protected float range;
    protected float damageDropOff;    // How much damage is reduced by for a given range.
    protected float swapSpeed;    // How long it take for a gun to be swapped to.
    protected float aimDownSightSpeed;    // How long it take to aim down the sight of the gun.

    protected PlayerInput.UseWeaponActions useWeapon;

    // Start is called before the first frame updat
    void Start()
    {
        
    }

    // Deal damage
    public virtual float DealDamage()
    {
        float dmg = CalculateDamage(damage);

        return dmg;
    }

    // Calculates the damage
    protected virtual float CalculateDamage(float dmg, float distance = 0)
    {
        float temp = dmg;


        return temp;
    }

    protected void Shoot()
    {
        Debug.Log("Shots Fired");
    }
}
