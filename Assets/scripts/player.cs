using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    public GameObject blockparticle;

    public GameObject flamethrower;
    public Animator anim;
    Rigidbody rb;

    public bool isStamina = false;

    public bool iswalking;
    
    manabar manabar;
    staminabar staminabar;
    public bool isMana = false;
    public bool isManablock = false;
    public bool isManafire = false;
    public float walkingspeed = 4f;
    public float runningSpeed = 5f;
    
    public float speed;
    public float rotationSpeed;
    
    // Start is called before the first frame update
    
    void Awake() 
    {
        staminabar = GameObject.FindGameObjectWithTag("staminabar").GetComponent<staminabar>();
        manabar = GameObject.FindGameObjectWithTag("manabar").GetComponent<manabar>();
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
        castfireball();

        debugmana();
    }


    

    void movement()
    {   
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //walking
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))))
        {   
            iswalking = true;
            speed = walkingspeed;
            anim.SetBool("bwalking", true);
            movementDirection.Normalize();
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
            iswalking = false;
            anim.SetBool("bwalking", false);
        }
        
        //&& !staminabar.nostamina
        //sprinting
        if (Input.GetKey(KeyCode.LeftShift) && iswalking && !staminabar.nostamina)
        {   
            speed = runningSpeed;
            isStamina = true;
            anim.SetBool("brunning", true);
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
        else 
        {   
            isStamina = false;
            anim.SetBool("brunning", false);
        }

        //rotation
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }

     
       
    }
    
    //debugmana 
    void debugmana()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            manabar.updatemana();
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
            isMana = true;
            isManablock = true;
            blockparticle.SetActive(true);
            anim.SetBool("bblocking",true);
        }
        else
        {
            isManablock = false;
            blockparticle.SetActive(false);
            anim.SetBool("bblocking", false);
        }
    }

    void castfireball()
    {   
        if (Input.GetKey(KeyCode.Alpha1))
        {
            isMana = true;
            isManafire = true;
            flamethrower.SetActive(true);
            anim.SetBool("isfireball", true);
        }
        else
        {
            isManafire = false;
            flamethrower.SetActive(false);
            anim.SetBool("isfireball", false);
        }
    }


    
}
