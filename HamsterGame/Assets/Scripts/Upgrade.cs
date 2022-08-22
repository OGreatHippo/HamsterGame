using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static BuildingManager;

public class Upgrade : MonoBehaviour
{
    private void Update()
    {
        if (buildingManager.cost[ID] <= buildingManager.currency.GetCurrency())
        {
            buildingManager.buildingList[ID].gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            buildingManager.buildingList[ID].gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public int ID;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text amountText;
    public TMP_Text priceText;

    public void UpdateUI()
    {
        amountText.text = $"{buildingManager.currentAmount[ID]}";
        titleText.text = $"{buildingManager.buildingNames[ID]}";
        descriptionText.text = $"{buildingManager.buildingDescription[ID]}";
        priceText.text = $"{buildingManager.cost[ID]}" + " Watts";
    }

    public void Buy()
    {
        if (buildingManager.cost[ID] <= buildingManager.currency.GetCurrency())
        {
            buildingManager.currency.SetCurrency(-buildingManager.cost[ID]);
            buildingManager.currentAmount[ID] += 1;
            buildingManager.cost[ID] += buildingManager.cost[ID] * 0.2f;
            buildingManager.cost[ID] = Mathf.Round(buildingManager.cost[ID] * 100f) / 100f;
            AddFunction();
            buildingManager.UpdateAllBuildingUI();
        }
    }

    private void AddFunction()
    {
        switch(ID)
        {
            case 0:
                buildingManager.currency.SetPassiveIncome(0.1f);
                break;
            case 1:
                buildingManager.currency.SetPassiveIncome(0.5f);
                break;
            case 2:
                buildingManager.currency.SetPassiveIncome(1f);
                break;
            case 3:
                buildingManager.currency.SetPassiveIncome(5f);
                break;
            case 4:
                buildingManager.currency.SetPassiveIncome(10f);
                break;
            case 5:
                buildingManager.currency.SetPassiveIncome(50f);
                break;
            case 6:
                buildingManager.currency.SetPassiveIncome(100f);
                break;
            case 7:
                buildingManager.currency.SetPassiveIncome(500f);
                break;
            case 8:
                buildingManager.currency.SetPassiveIncome(1000f);
                break;
            case 9:
                buildingManager.currency.SetPassiveIncome(5000f);
                break;
            case 10:
                buildingManager.currency.SetPassiveIncome(10000f);
                break;
            case 11:
                buildingManager.currency.SetPassiveIncome(50000f);
                break;
            case 12:
                buildingManager.currency.SetPassiveIncome(100000f);
                break;
            case 13:
                buildingManager.currency.SetPassiveIncome(500000f);
                break;
            case 14:
                buildingManager.currency.SetPassiveIncome(1000000f);
                break;
            case 15:
                buildingManager.currency.SetPassiveIncome(5000000f);
                break;
            case 16:
                buildingManager.currency.SetPassiveIncome(10000000f);
                break;
            case 17:
                buildingManager.currency.SetPassiveIncome(50000000f);
                break;
            case 18:
                buildingManager.currency.SetPassiveIncome(100000000f);
                break;
            case 19:
                buildingManager.currency.SetPassiveIncome(500000000f);
                break;
            default:
                break;
        }; 
    }
}
