using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    Animator anim;
    Rigidbody rb;

    staminabar staminabar;
    public float speed;
    public float runningSpeed;
    
    public float rotationSpeed;
    
    // Start is called before the first frame update
    
    void Awake() 
    {
        staminabar = GameObject.FindGameObjectWithTag("staminabar").GetComponent<staminabar>();
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
        swingsword();
        block();
        
    }


    

    void movement()
    {   
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //walking
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))))
        {
            anim.SetBool("bwalking", true);
            movementDirection.Normalize();
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
            anim.SetBool("bwalking", false);
        }
        //sprinting
        if (Input.GetKey(KeyCode.LeftShift) && staminabar.stamina >= 10)
        {   
            staminabar.staminacost();
            anim.SetBool("brunning", true);
            transform.Translate(movementDirection * runningSpeed * Time.deltaTime, Space.World);
        }
        else 
        {   
            anim.SetBool("brunning", false);
            
        }

        //rotation
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }
    }

    

    

    void swingsword()
    {
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("bhit", true);
        }   
        else
        {
            anim.SetBool("bhit", false);
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
