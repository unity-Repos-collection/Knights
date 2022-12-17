using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manabar : MonoBehaviour
{
    private Image manaBar;
    
    private WaitForSeconds regentick = new WaitForSeconds(1f);
    

    private float manaCost = 0.1f; 
    private const float max_mana = 100f;
    
    [Range(0,100)]
    public float mana = max_mana;
    
    public float add_mana = 20f;

    
    
    void Awake() 
    {
        manaBar = GetComponent<Image>();
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        manaBar.fillAmount = mana / max_mana;
    }
    
    public void updatemana()
    {   
        mana += add_mana;
        if (mana >= 100)
        {
            mana = max_mana;
        }
    }

    public void manacost()
    {   
        mana -= manaCost;
        if (mana <= 0)
        {
            mana = 0;
        }
    }
    
    
}

