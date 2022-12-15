using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_gate : MonoBehaviour
{
    Animator anim;
    
    BoxCollider boxCollider;
    
    // Start is called before the first frame update
    public bool isdungeon = false;
    void Awake() 
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {   
        if (other.gameObject.CompareTag("Player") && isdungeon)
        {
            Debug.Log("opening");
            boxCollider.enabled = false;
            anim.SetBool("Bopen_gate", true);    
        }
    }
    
    
    
    private void OnTriggerExit(Collider other) 
    {   
        boxCollider.enabled = true;
        Debug.Log("closing");
        anim.SetBool("Bopen_gate", false);    
    }
}
