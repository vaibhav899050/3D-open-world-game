
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform PlayerBody;
    private float xRotatin;
    bool isseated = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

       
        
        bool fpress = Input.GetKey("f");
        bool epress = Input.GetKey("e");
        if (epress)
        {
            isseated = false;
        }
        if (fpress)
        {
            isseated = true;
        }
        if (!isseated)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotatin -= mouseY;
            xRotatin = Mathf.Clamp(xRotatin, -90f, 40f);
            transform.localRotation = Quaternion.Euler(xRotatin, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
        if (!isseated)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotatin -= mouseY;
            xRotatin = Mathf.Clamp(xRotatin, -90f, 40f);
            transform.localRotation = Quaternion.Euler(xRotatin, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
        
    }
}
