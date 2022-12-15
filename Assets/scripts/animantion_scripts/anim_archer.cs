using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_archer : MonoBehaviour
{
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
    private void OnCollisionEnter(Collision collision) 
    {
        anim.SetBool("Barcher", true);    
    }
}
