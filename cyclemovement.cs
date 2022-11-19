using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyclemovement : MonoBehaviour
{
    public Transform player;
    public Transform cycle;
    public float speed = 50f;
    public CharacterController controller;
    public float omega = 12f;
    public Transform rotationaxis;
    bool isseated = false;
    Vector3 velocity;
    public float gravity = -7f;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    public float stamina = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        bool fpress = Input.GetKey("f");
        bool epress = Input.GetKey("e");
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }

        if (!isseated && fpress)
        {
            isseated = true;
        }
        if (isseated && epress)
        {
            isseated = false;
        }
        if (isseated)
        {

            

            bool wpress = Input.GetKey("w");
            
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (wpress)
            {
                rotationaxis.Rotate(0, x * omega * Time.deltaTime, 0);
                
                stamina -= 0.1f;
                if (stamina > 0)
                {
                    speed += 0.01f;

                }
            }
            Vector3 move = -transform.right * z;
            controller.Move(move * speed * Time.deltaTime);
            
            
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
