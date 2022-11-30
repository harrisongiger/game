using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ThirdPersonPlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody rb;
    Vector3 myInput;
    Vector3 moveVelocity;
   // public CameraMovement cameraMovement;
    public Camera mainCamera;
    public GameObject deathText;
    public int health = 3;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        deathText.SetActive(false);
    }

    void Update()
    {
        myInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = myInput * moveSpeed;

        if (mainCamera.GetComponent<CameraMovement>().firstPerson == false)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }

        if (health == 0)
        {
            death();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    public void death()
    {
        gameObject.SetActive(false);
        deathText.SetActive(true);
    }
}
