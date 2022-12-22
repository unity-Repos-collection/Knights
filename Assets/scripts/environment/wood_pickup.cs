using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood_pickup : MonoBehaviour
{
    
   
    [SerializeField] AudioClip woodpickupsound;
    AudioSource AudioSource;
    [SerializeField] bank bank;
    public GameObject woodpickup;

    

    void Awake() 
    {
        AudioSource = GetComponent<AudioSource>(); 
        bank = GameObject.FindGameObjectWithTag("bank").GetComponent<bank>();  
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
        if (other.gameObject.CompareTag("Player"))
        {
            float randomspawntime = Random.Range(0f, 60f);
            StartCoroutine(respawnwood());
            Invoke(nameof(spawnwood), randomspawntime * 2);
        }    
        
    }

    void playwoodsound()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(woodpickupsound);
    }


    IEnumerator respawnwood()
    {
        playwoodsound();
        yield return new WaitForSeconds(0.5f);
        bank.addwood();
        woodpickup.gameObject.SetActive(false);
    } 
    void spawnwood() 
    {
        woodpickup.gameObject.SetActive(true);
    }
}
