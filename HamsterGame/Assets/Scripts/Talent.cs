using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TalentTree;
using UnityEngine.UI;

public class Talent : MonoBehaviour
{
    public int ID;

    private Clicker clicker;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text amountText;
    public TMP_Text priceText;

    public int[] connectedTalents;

    public xpBar talentSpentBar;

    private void Start()
    {
        clicker = GameObject.Find("ClickSprite").GetComponent<Clicker>();
    }

    public void UpdateUI()
    {
        amountText.text = $"{talentTree.currentTalentLevels[ID]}/{talentTree.maxTalentLevels[ID]}";
        titleText.text = $"{talentTree.talentNames[ID]}";
        descriptionText.text = $"{talentTree.talentDescription[ID]}";
        priceText.text = $"{talentTree.talentCost[ID]}" + " :TP";
        talentSpentBar.SetMaxXP(talentTree.maxTalentLevels[ID]);
        talentSpentBar.SetXP(talentTree.currentTalentLevels[ID]);

        foreach (var connectedTalent in connectedTalents)
        {
            if(talentTree.currentTalentLevels[ID] > 0)
            {
                talentTree.talentList[connectedTalent].gameObject.GetComponent<Button>().interactable = true;
            }
        }

        if(talentTree.currentTalentLevels[ID] == talentTree.maxTalentLevels[ID])
        {
            talentTree.talentList[ID].gameObject.GetComponent<Button>().interactable = false;
            GetComponent<Image>().color = Color.green;
        }
    }

    public void Buy()
    {
        if(talentTree.talentAmount.GetTalents() >= talentTree.talentCost[ID] && talentTree.currentTalentLevels[ID] != talentTree.maxTalentLevels[ID])
        {
            talentTree.talentAmount.SetTalents(talentTree.talentCost[ID]);
            talentTree.currentTalentLevels[ID]++;
            AddFunction();
            talentTree.UpdateAllTalentUI();
        } 
    }

    private void AddFunction()
    {
        switch(ID)
        {
            case 0:
                clicker.SetClickValue(0.1f);
                break;
            case 1:
                talentTree.talentAmount.SetFrenzyTime(1f);
                break;
            case 2:
                clicker.AddPercentagePerClick(1);
                break;
            case 3:
                talentTree.talentAmount.SetFrenzyMultiplier(1);
                break;
            case 4:
                clicker.SetMultiplier(1);
                break;
            case 5:
                clicker.SetMultiplier(10);
                break;
            case 6:
                talentTree.talentAmount.SetCurrencyTimer(600);
                break;
            case 7:
                talentTree.talentAmount.SetDoubleCurrencyTime(600);
                break;
            case 8:
                talentTree.talentAmount.SetDoubleXPTime(600);
                break;
            default:
                break;
        };
    }
}
