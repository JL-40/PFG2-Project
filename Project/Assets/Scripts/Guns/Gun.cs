using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public enum AmmoType
{
    Single,
    Pellet
}

public abstract class Gun : MonoBehaviour
{
    public int magazineAmmoCount;  // How much ammo is in the gun's magazine.
    public int magazineCapacity;     // Maximum bullets in the clip
    public int reserveAmmoCount;   // How much ammo the gun has to reload from.
    public AmmoType cartridge;     // The type of ammo the gun uses (Single bullet or a pellet of multiple bullets.
    public int pelletCount = 0;    // The amount of pellets the gun shoots.

    // How much damage each shot does, how fast the gun shoots, how fast the burst is, the range, and how much spread the gun has
    public float damage, rateOfFire, burstRate, range, spread;
    public int bulletsPerTap;    // How many bullets are shot per mouse click
    public bool allowSpray;     // Allows he gun to shoot continously as long has the button is pressed

    public bool isShooting, readyToShoot, isReloading;   // Status of the gun

    public PlayerInput playerInput;
    public PlayerInput.UseWeaponActions useWeapon;

    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask enemyDetector;

    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI reserveAmmoText;

    
    public GameObject bulletPrefab;
    public Transform bulletSpawner;
    public ParticleSystem muzzleFlash;

    // Start is called before the first frame updat
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(-attackPoint.rotation.eulerAngles.x, attackPoint.rotation.eulerAngles.y + 180f, -attackPoint.rotation.eulerAngles.z);
    }

    // Deal damage
    public virtual float DealDamage(float dmg)
    {
        float dmgOut = CalculateDamage(dmg);

        return dmgOut;
    }

    // Calculates the damage
    public virtual float CalculateDamage(float dmg, float distance = 0)
    {
        float temp = dmg;


        return temp;
    }

    public virtual void Shoot()
    {
        Debug.Log("Shots Fired");
    }

    public virtual void ShootBullet()
    {
        muzzleFlash.Play();     // Play Muzzle Flash

        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        newBullet.GetComponent<Bullet>().SetDirection(attackPoint.transform.forward);
    }

    public virtual void Reload()
    {
        Debug.Log("Reloading");
    }

    public virtual void UpdateAmmo()
    {
        Debug.Log($"Current Ammo {magazineAmmoCount} - Current Reserve {reserveAmmoCount}");
    }

    public virtual void HitEnemy(float rng, float dmg)
    {
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out rayHit, rng, enemyDetector))
        {
            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<Enemy>().DisplayDamage(dmg);
            }
        }
    }
}
