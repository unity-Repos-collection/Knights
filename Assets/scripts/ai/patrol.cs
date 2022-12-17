using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    
    public Transform[] points;
    int current;
    public float speed;

    void Awake() 
    {
        
            
    }
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
            points[current].position, speed * Time.deltaTime);    
        }
        else
        {
            current=(current+1);
        }
    }

}
