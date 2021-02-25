using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{   

    public float mouseSensitivity = 2000f;

    public Transform playerBody;

    float xRotation = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        
        //Gets mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        //Locks Rotation angle 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Rotates player camera on the x axis
        transform.localRotation = Quaternion.Euler( xRotation, 0f, 0f);
        //Rotates the player on the y axis 
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
