using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood_pickup : MonoBehaviour
{
    
    [SerializeField] bank bank;
    public GameObject woodpickup;

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
            Destroy(woodpickup);
            Invoke(nameof(spawnwood), 0.1f);
        }    
    }

    void spawnwood()
    {
        //woodpickup.gameObject.SetActive(true);
        Vector3 Pos = woodpickup.transform.position;
        Instantiate(woodpickup, Pos, Quaternion.identity);
    }
}
