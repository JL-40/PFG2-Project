using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI seperator;

    [SerializeField] GameObject SaveMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        SaveMenu.SetActive(false);

        seperator.text = "/";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!SaveMenu.activeSelf)
            {
                SaveMenu.SetActive(true);
            }
            else
            {
                SaveMenu.SetActive(false);
            }
        }
    }
}
