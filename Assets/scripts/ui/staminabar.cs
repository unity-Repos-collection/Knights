using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminabar : MonoBehaviour
{
    private Image staminaBar;
    
    private WaitForSeconds regentick = new WaitForSeconds(1f);
    private WaitForSeconds costtick = new WaitForSeconds(0.1f);

    private float staminaCost = 0.1f; 
    private const float max_stamina = 100f;
    
    [Range(0,100)]
    public float stamina = max_stamina;
    
    public float add_stamina = 20f;

    
    
    void Awake() 
    {
        staminaBar = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(staminaRegen()); 
        //StartCoroutine(staminacost());
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.fillAmount = stamina / max_stamina;
    }
    
    public void updatestamina()
    {   
        stamina += add_stamina;
        if (stamina >= 100)
        {
            stamina = max_stamina;
        }
    }

    public void staminacost()
    {   
        stamina -= staminaCost;
        if (stamina <= 0)
        {
            stamina = 0;
        }
    }
    
    // increase stamina over time 
    private IEnumerator staminaRegen()
    {   
        yield return new WaitForSeconds(2);

        while(stamina < max_stamina)
        {
            stamina += max_stamina / 100;
            yield return regentick;
        }
    }
}

