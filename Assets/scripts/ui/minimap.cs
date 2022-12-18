using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void LateUpdate() 
    {
           miniMapCameraFollow();
    }

    void miniMapCameraFollow()
    {
        Vector3 newposition = player.position;
        newposition.y = transform.position.y;
        transform.position = newposition;
    }
}
