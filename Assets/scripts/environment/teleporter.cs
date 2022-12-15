using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleporter : MonoBehaviour
{
    private void OnTriggerenter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            Debug.Log("teleporting");
        }
    }

    
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            Invoke(nameof(teleport), 3f);
        }
    }
    void teleport()
    {
        SceneManager.LoadScene(3);
    }
}
