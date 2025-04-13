using System.Collections;
using System.Collections.Generic;
using StarterAssets;
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
    public int dashPoint;
    public float dashSpeed;
    public float dashTime;
    private ThirdPersonController thirdPersonController;

    void Start()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
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
    }

    void Update()
    {
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
                thirdPersonController.MoveSpeed = 2f;
                activateSpeed = false;
                Debug.Log("Speed Deactivated");
            }
        }
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
            thirdPersonController.MoveSpeed += 10f;
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