using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_gate : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update

    void Awake() 
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) 
    {   
        Debug.Log("opening");
        anim.SetBool("Bopen_gate", true);    
    }
    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("closing");
        anim.SetBool("Bopen_gate", false);    
    }
}
