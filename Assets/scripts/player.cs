using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    Animator anim;
    Rigidbody rb;
    private float movementspeed = 1f;
    // Start is called before the first frame update
    
    void Awake() 
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        hit();
        block();
    }


    void hit()
    {
        if (Input.GetKey(KeyCode.E))
            anim.SetBool("bhit", true);
            
        else
             anim.SetBool("bhit", false);  
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("bwalking",true);
            transform.Translate(0,0,1 * movementspeed *Time.deltaTime);
        }
        else
        {
            anim.SetBool("bwalking",false);
        }

        if (Input.GetKey(KeyCode.A))
        {   
            anim.SetBool("bwalking",true);
            transform.Translate(0,0,-1 * movementspeed *Time.deltaTime);
        }
    }

    void block()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("bblocking",true);
        }
        else
        {
            anim.SetBool("bblocking", false);
        }
    }

}
