using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom_pickup : MonoBehaviour
{
   
    public float soundelay = 0.5f;
    healthbar healthbar;
    manabar manabar;

    [SerializeField] AudioClip ManaEatSound;
    [SerializeField] AudioClip HealthEatSound;
    AudioSource audioSource;
    [SerializeField] GameObject Object;
    
    [SerializeField] float rotatespeed;
    Vector3 startingposition;
    [SerializeField] Vector3 movementvector;
    float movementfactor; 
    [SerializeField] float Period = 2f;
    
    
    void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
        manabar =  GameObject.FindGameObjectWithTag("manabar").GetComponent<manabar>();
        healthbar = GameObject.FindGameObjectWithTag("healthbar").GetComponent<healthbar>();    
    }
    void Start()
    {
        //get transform of object
        startingposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sinwave();
        spin();
    }
    void sinwave()
    {
        if (Period <= Mathf.Epsilon) {return;}
        float cycles = Time.time / Period; // growing over time
        const float tau = Mathf.PI * 2f; // constant value of 6.283
        float RawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1
        movementfactor = (RawSinWave + 1f) / 2f; // recalculated to go from 0 to 1
        Vector3 offset = movementvector * movementfactor; 
        transform.position = startingposition + offset;
    }
    void spin()
    {
        transform.Rotate(0,1,0 * rotatespeed * Time.deltaTime);
    }

    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            if (Object.tag == "health")
            {
                healtheatsound();
                healthbar.updatehealth();
                Invoke(nameof(Destroy), soundelay);   
                Debug.Log("health");
            }
            else if (Object.tag == "mana")
            {
                manaeatsound();
                manabar.updatemana();
                Invoke(nameof(Destroy), soundelay);  
                Debug.Log("mana");
            }
            
                
            
        }
    }
    
    void healtheatsound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(HealthEatSound);

    }
    void manaeatsound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(ManaEatSound);
    }

    void Destroy() 
    {
        Destroy(Object);
    }

}
