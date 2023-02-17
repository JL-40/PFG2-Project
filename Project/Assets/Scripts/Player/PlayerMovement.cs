/*
 * Created using a Youtube tutorial
 * Credits to Natty Creations
 * Source: https://www.youtube.com/watch?v=rJqP5EesxLk
 */

using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
    Rigidbody rb;

    bool isGrounded;

    public float playerSpeed;
    public float gravityScale = -9.8f;
    public float jumpForce;

    static Vector3 playerLoc;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerLocation();

        isGrounded = controller.isGrounded;
    }

    void UpdatePlayerLocation()
    {
        playerLoc = gameObject.transform.position;
    }

    public static Vector3 GetPlayerLocation()
    {
        return playerLoc;
    }

    public void ProcessMovement(Vector2 input)
    {
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = input.x;
        movementDirection.z = input.y;
        controller.Move(transform.TransformDirection(movementDirection) * playerSpeed * Time.deltaTime);

        playerVelocity.y += gravityScale * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3 * gravityScale);
        }
    }
}
