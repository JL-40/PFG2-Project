using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int reserveAmmo;
    public int magazineAmmo;
    public float health;
    public Vector3 position;

    public PlayerData(int reserve, int magazine, float hp, Vector3 pos)
    {
        reserveAmmo = reserve;
        magazineAmmo = magazine;
        health = hp;
        position = pos;
    }
}
