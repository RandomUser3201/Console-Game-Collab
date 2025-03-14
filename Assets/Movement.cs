using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    //[Camera Controls]
    public Transform cameraTransform;
    public float mouseSensitivity = 200f;
    public float distanceFromPlayer = 5f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    public Rigidbody rb;
    public TrailRenderer tr;

    public float speed = 5f;
    public float speedTimer = 0;
    private bool activateSpeed = false;

    private bool activateDash = false;
    private int dashPoint;
    public float dashSpeed;
    public float dashTime;


    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

        tr = GetComponent<TrailRenderer>();
        tr.emitting = false;
        if (tr == null)
        {
            Debug.LogError("TrailRenderer component missing on the Player");
        }

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing on the Player.");
        }

        // if (cameraTransform == null)
        // {
        //     cameraTransform = Camera.main.transform;
        //     if (cameraTransform == null)
        //     {
        //         Debug.LogError("No camera assigned, and no Main Camera found in the scene!");
        //     }
        // }

    }

    void Update()
    {
        // // Handle mouse input
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // //Debug.Log($"MouseX: {mouseX}, MouseY: {mouseY}");

        // // Update rotation values
        // rotationY += mouseX;
        // rotationX -= mouseY;

        // // Clamped vertical rotation to prevent flipping
        // rotationX = Mathf.Clamp(rotationX, -35f, 60f);

        // // Apply rotation to the camera
        // cameraTransform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // // Updated the camera position relative to the player
        // cameraTransform.position = transform.position - cameraTransform.forward * distanceFromPlayer + Vector3.up * 1.5f;


        if (dashPoint > 0)
        {
            Debug.LogWarning("Dash Activated");
            activateDash = true;
        }
        else 
        {
            // Debug.LogWarning("Dash Deactivated");
            activateDash = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (activateDash)
            {
                Debug.Log("dash");
                StartCoroutine(Dash());
                tr.time = 0.3f;
                dashPoint--;
            }
        }

        if (activateSpeed)
        {
            if (speedTimer > 0)
            {
                speedTimer -= Time.deltaTime;
            }
            else
            {
                speed = 10f;
                activateSpeed = false;
                Debug.Log("Speed Deactivated");
            }
        }
    }

    void FixedUpdate()
    {
        // // Get input from WASD or arrow keys
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        // if (horizontal == 0f && vertical == 0f)
        //     return;

        // // Get the forward and right directions from the camera
        // Vector3 cameraForward = cameraTransform.forward;
        // Vector3 cameraRight = cameraTransform.right;

        // // Flatten directions on the horizontal plane
        // cameraForward.y = 0f;
        // cameraRight.y = 0f;

        // cameraForward.Normalize();
        // cameraRight.Normalize();

        // // Calculate movement direction
        // Vector3 movement = (cameraForward * vertical + cameraRight * horizontal).normalized;

        // // Move the player
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        // // Rotate the player to face the movement direction
        // if (movement.magnitude > 0)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        //     rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        // }

        // // Debug movement direction
        // Debug.DrawRay(transform.position, movement * 5f, Color.green);
    }

    IEnumerator Dash()
    {
        tr.emitting = true;

        float startTime = Time.time;
        while(Time.time < startTime + dashTime)
        {
            transform.Translate(Vector3.forward * dashSpeed);
            yield return null;
        }

        tr.emitting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PSpeed"))
        {
            Debug.LogWarning("Collided with Speed Powerup");    
            speedTimer = 5;
            speed = 100f;
            activateSpeed = true;
         
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "PDash")
        {
            dashPoint++;
            Debug.LogWarning("Dash Point: " + dashPoint);
            Debug.LogWarning("Collided with Dash Powerup");

            Destroy(other.gameObject);
        }
    }
}

// Unity 2020 Tutorial: SIMPLE Dashing in 3D [w/ 'Character Controller' Component] https://www.youtube.com/watch?v=vTNWUbGkZ58