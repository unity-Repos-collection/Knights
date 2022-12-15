using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmushroomparticle : MonoBehaviour
{
    public ParticleSystem mushroom;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            playmushroom();
            
        }
    }

    void playmushroom()
    {
        mushroom.Play();
    }
}
