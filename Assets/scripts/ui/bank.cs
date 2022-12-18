using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displaywood;
    [SerializeField] TextMeshProUGUI displaymoney;
    [SerializeField] int startingWoodbalance = 10;
    [SerializeField] int startingMoneybalance = 10;

    [SerializeField] int currentWoodbalance;
    [SerializeField] int currentMoneybalance;

    [SerializeField] int wood = 1;
    [SerializeField] int money = 1;
    void Awake() 
    {
        currentMoneybalance = startingMoneybalance;
        currentWoodbalance = startingWoodbalance;   
        updateWoodDisplay();
        updateMoneyDisplay();

    }
    public void addwood()
    {
        currentWoodbalance = currentWoodbalance + wood;
        updateWoodDisplay();
    }
    public void minuswood()
    {

    }

    public void deposit()
    {
        currentMoneybalance = currentMoneybalance + money;
        updateMoneyDisplay(); 
    }

    public void withdraw()
    {

    }

    void updateMoneyDisplay()
    {
        displaymoney.text = "Gold: " + currentMoneybalance;
    }


    void updateWoodDisplay()
    {
        displaywood.text = "Wood: " + currentWoodbalance; 
    }
}
