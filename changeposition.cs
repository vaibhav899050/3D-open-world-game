using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeposition : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject cycle = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool epress = Input.GetKey("e");
        
        if (epress)
        {
            player.transform.position = cycle.transform.position - cycle.transform.TransformDirection(Vector3.left);
            player.transform.rotation = cycle.transform.rotation;
            
            
        }
    }
}
