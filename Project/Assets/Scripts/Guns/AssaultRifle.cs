using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AssaultRifle : Gun
{
    public AssaultRifle()
    {
        magazineAmmoCount = 30;
        magazineCapacity = 30;
        reserveAmmoCount = 150;
        cartridge = AmmoType.Single;

        damage = 33f;
        rateOfFire = 5f;

        allowSpray = true;

        isShooting = false;
        readyToShoot = true;
        isReloading = false;
    }

    void Awake()
    {
        playerInput = new PlayerInput();
        useWeapon = playerInput.UseWeapon;

        useWeapon.ShootGun.performed += ctx => Shoot();
        useWeapon.ReloadGun.performed += ctx => Reload();
    }
    void OnEnable()
    {
        useWeapon.Enable();
    }
    void OnDisable()
    {
        useWeapon.Disable();
    }

    void Start()
    {
        UpdateAmmo();
  
    }

    public override void Shoot()
    {
        if (magazineAmmoCount > 0)
        {
            magazineAmmoCount--;
        }

        UpdateAmmo();
    }

    public override void Reload()
    {
        // Do not reload if the gun is full, there is no more ammo to reload from, or the gun is already reloading
        if (magazineAmmoCount < magazineCapacity && reserveAmmoCount > 0 && !isReloading)
        {

            isReloading = true;     // Gun is reloading

            int ammoTaken;

            // Check if there is less reserve ammo than the amount of ammo needed to refill a full magazine
            if (reserveAmmoCount < magazineCapacity - magazineAmmoCount)
            {
                ammoTaken = reserveAmmoCount;

                reserveAmmoCount -= reserveAmmoCount;

                magazineAmmoCount += ammoTaken;
            }
            else
            {
                ammoTaken = magazineCapacity - magazineAmmoCount;

                reserveAmmoCount -= ammoTaken;

                magazineAmmoCount += ammoTaken;
            }

            UpdateAmmo();

            isReloading = false;
        }
    }

    public override void UpdateAmmo()
    {
        currentAmmoText.text = magazineAmmoCount.ToString();
        reserveAmmoText.text = reserveAmmoCount.ToString();

        if (magazineAmmoCount <= 15)
        {
            currentAmmoText.color = Color.red;
        }
        else
        {
            currentAmmoText.color = Color.black;
        }

        if (reserveAmmoCount <= 15)
        {
            reserveAmmoText.color = Color.red;
        }
        else
        {
            reserveAmmoText.color = Color.black;
        }
    }
}
