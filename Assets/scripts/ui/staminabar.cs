using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class staminabar : MonoBehaviour
{
    player player;
    public float stamina;
    public float maxstamina;
    public bool nostamina = false;

    public Slider staminawheel;
    public Slider usagewheel;
    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
       stamina = maxstamina;
       
    }

    // Update is called once per frame
    void Update()
    {
        staminacost();
    }

    void staminacost()
    {
        if (player.isStamina)
        {
            if (stamina > 0)
            {
                stamina -= 10 * Time.deltaTime; 
            }

            usagewheel.value = stamina / maxstamina + 0.05f;
        }
        else
        {
            if (stamina < maxstamina)
            {   
                
                stamina += 30 *  Time.deltaTime;
            }
            if (stamina >= 100)
            {
                nostamina = false;
            }
            usagewheel.value = stamina / maxstamina;
        }

        staminawheel.value = stamina / maxstamina;

        if (stamina <= 0)
        {
            nostamina = true;
            player.anim.SetBool("brunning", false);
            
        }
    }


    
}
