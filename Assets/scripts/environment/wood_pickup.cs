using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood_pickup : MonoBehaviour
{
    
    [SerializeField] bank bank;
    public GameObject woodpickup;

    private System.Random rand = new System.Random();

    void Awake() 
    {
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
            bank.addwood();
            woodpickup.gameObject.SetActive(false);
            Invoke(nameof(Spawnwood), 60f);
        }    
        
    }


    void Spawnwood()
    {
        woodpickup.gameObject.SetActive(true); 
    }
}
