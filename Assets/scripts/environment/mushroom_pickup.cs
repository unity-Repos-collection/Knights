using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom_pickup : MonoBehaviour
{
    [SerializeField] float respawntime = 60f;
    
    healthbar healthbar;
    manabar manabar;

    [SerializeField] AudioClip ManaEatSound;
    [SerializeField] AudioClip HealthEatSound;
    AudioSource audioSource;

    
    [SerializeField] GameObject mushroom;
    
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
            if (mushroom.tag == "health")
            {
                StartCoroutine(respawnhealth());
                Invoke(nameof(spawnmushroom), respawntime);
                
                
            }
            else if (mushroom.tag == "mana")
            {
                StartCoroutine(respawnMana());
                Invoke(nameof(spawnmushroom), respawntime);
                
                
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

    void spawnmushroom() 
    {
        mushroom.gameObject.SetActive(true);
    }
    
    IEnumerator respawnhealth()
    {
        healtheatsound();
        yield return new WaitForSeconds(0.5f);
        healthbar.updatehealth();
        mushroom.gameObject.SetActive(false);
    } 
    IEnumerator respawnMana()
    {
        manaeatsound();
        yield return new WaitForSeconds(0.5f);
        manabar.updatemana();
        mushroom.gameObject.SetActive(false);
    } 
    
   

}
