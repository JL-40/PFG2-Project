/*
 * Created using a Youtube tutorial
 * Credits to Natty Creations
 * Source: https://www.youtube.com/watch?v=rJqP5EesxLk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.OnFootActions onFoot;
    PlayerMovement playerMovement;
    PlayerLook playerLook;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => playerMovement.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Tells the player movement script to move using the binds we set in the input system
        playerMovement.ProcessMovement(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    void OnEnable()
    {
        onFoot.Enable();
    }

    void OnDisable()
    {
        onFoot.Disable();
    }
}
