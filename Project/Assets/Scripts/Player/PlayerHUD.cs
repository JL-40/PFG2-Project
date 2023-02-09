using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI seperator;

    // Start is called before the first frame update
    void Start()
    {
        seperator.text = "/";
    }
}
