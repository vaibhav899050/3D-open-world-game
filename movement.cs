using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    bool isseated = false;
    public GameObject maincam;
    public GameObject cyclecam;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject cycle = null;
    public GameObject animati = null;
    public Transform cycleposition;
    Vector3 velocity;
    public float gravity = -10f;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    float mindistance = 3f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        maincam.SetActive(true);
        cyclecam.SetActive(false);
        /*if (!isLocalPlayer)
        {
            maincam.SetActive(false);
        }*/
    }
    
    
    // Update is called once per frame
    void Update()
    {
        /*if(!isLocalPlayer)
        {
            animati.GetComponent<Animation>().enabled = false;
            return;
        }*/
        float dis = Vector3.Distance(cycle.transform.position, player.transform.position);
        bool fpress = Input.GetKey("f");
        bool wpress = Input.GetKey("w");
        bool epress = Input.GetKey("e");
        bool shiftpress = Input.GetKey("left shift");
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        
        
        if (isseated && epress)
        {
            isseated = false;
            maincam.SetActive(true);
            cyclecam.SetActive(false);
        }
        if (fpress && !isseated)
        {
            isseated = true;
            maincam.SetActive(false);
            cyclecam.SetActive(true);
        }
        if (!isseated)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            bool shiftpresss = Input.GetKey("left shift");
            Vector3 move = transform.right * x + transform.forward * z;
            if (shiftpresss)
            {
                controller.Move(move * speed * Time.deltaTime * 1.5f);
            }
            if (!shiftpresss)
            {
                controller.Move(move * speed * Time.deltaTime);
            }
            
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (wpress && !isseated)
        {
            animator.SetBool("wpress", true);
        }
        if (!wpress && !isseated)
        {
            animator.SetBool("wpress", false);
        }
        if (shiftpress && !isseated)
        {
            animator.SetBool("shiftpress", true);
        }
        if (!shiftpress && !isseated)
        {
            animator.SetBool("shiftpress", false);
        }
        if (wpress && shiftpress && !isseated)
        {
            animator.SetBool("wpress", true);
            animator.SetBool("shiftpress", true);
        }



        /*if (isseated)
        {
            player.transform.position = cycle.transform.position - cycle.transform.TransformDirection(Vector3.left);
            player.transform.rotation = cycle.transform.rotation;
        }
        if (isseated && wpress)
        {
            cycle.transform.localPosition = new Vector3(1.7f, 0.5f, -0.9653f);
        }
        if (isseated && !wpress)
        {
            //cycle.transform.localPosition = new Vector3(3.46f, 1.39f, -0.9653f);
        }*/



    }
}
