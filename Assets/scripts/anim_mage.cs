using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_mage : MonoBehaviour
{   
    float number = 1f; 
    Animator anim;
    void Awake() 
    {
        anim = GetComponent<Animator>();
    }
    
    
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "player" )
        {
            movemage();
        }
    }

    public void movemage()
    {
        anim.SetBool("hellomage", true);
    }
}
