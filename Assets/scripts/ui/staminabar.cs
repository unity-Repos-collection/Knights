using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminabar : MonoBehaviour
{
    private Image staminaBar;
    
    public WaitForSeconds regentick = new WaitForSeconds(1f);
    

    private float StaminaCost = 0.1f; 
    private const float max_Stamina = 100f;
    
    [Range(0,100)]
    public float Stamina = max_Stamina;
    
    public float add_Stamina = 20f;
    
    void Awake() 
    {
        staminaBar = GetComponent<Image>();    
    }
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(StaminaRegen()); 
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.fillAmount = Stamina / max_Stamina;
    }
    
    public void staminacost()
    {   
        Stamina -= StaminaCost;
        if (Stamina <= 0)
        {
            Stamina = 0;
        }
    }

    // increase stamina over time 
    private IEnumerator StaminaRegen()
    {   
        yield return new WaitForSeconds(2);

        while(Stamina < max_Stamina)
        {
            Stamina += max_Stamina / 100;
            yield return regentick;
        }
    }
}
