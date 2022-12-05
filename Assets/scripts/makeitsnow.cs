using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeitsnow : MonoBehaviour
{
    [SerializeField] ParticleSystem hail1;
    [SerializeField] ParticleSystem hail2;

    [SerializeField] ParticleSystem hail3;
    [SerializeField] ParticleSystem hail4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
     

    
    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            Debug.Log("hailing");
            makeithail();
            
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("stop hailing");
        stophail();
    }
    void makeithail()
    {
        hail1.Play();
        hail2.Play();
        hail3.Play();
        hail4.Play();
    }
    void stophail()
    {
        hail1.Stop();
        hail2.Stop();
        hail3.Stop();
        hail4.Stop();
    }
}

