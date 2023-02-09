using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI promptText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
