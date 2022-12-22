using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{
    private Image healthBar;
 
    private const float max_health = 100f;
    
    [Range(0,100)]
    public float health = max_health;
    
    public float add_health = 20f;
    
    void Awake() 
    {
        healthBar = GetComponent<Image>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / max_health; 
    }
    
    
    
    
    
    
    
    
    public void updatehealth()
    {   
        health += add_health;
        if (health >= 100)
        {
            health = max_health;
        }
        //Debug.Log("health up");
    }
}
