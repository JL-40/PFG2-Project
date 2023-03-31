using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerHealth playerHP;
    [SerializeField] Gun gun;
    [SerializeField] PlayerData saveData;
    [SerializeField] SaveManager saver;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = player.GetComponent<PlayerHealth>();
        gun = player.transform.GetChild(0).GetChild(0).GetComponent<Gun>();
    }

    public void SetData()
    {
        saveData = new PlayerData(gun.reserveAmmoCount, gun.magazineAmmoCount, playerHP.GetHealth(), transform.position);

        saver.SaveData(saveData);
    }

    public void LoadData()
    {
        PlayerData data = saver.LoadData();

        if (data != null)
        {
            playerHP.SetHealth(data.health);
            gun.reserveAmmoCount = data.reserveAmmo;
            gun.magazineAmmoCount = data.magazineAmmo;

            transform.position = data.position;
        }
    }
}
