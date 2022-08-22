using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentTree : MonoBehaviour
{
    public static TalentTree talentTree;

    public Main talentAmount;

    public int[] currentTalentLevels;
    public int[] talentCost;
    public int[] maxTalentLevels;
    public string[] talentNames;
    public string[] talentDescription;

    public List<Talent> talentList;
    public GameObject talentHolder;

    public List<GameObject> connectorList;
    public GameObject connectorHolder;

    private void Awake()
    {
        talentTree = this;
    }

    private void Start()
    {
        talentAmount = GameObject.Find("GameHandler").GetComponent<Main>();

        currentTalentLevels = new int[13];
        talentCost = new[] { 1, 1, 1, 10, 1, 100, 1, 1, 1, 1, 1, 1, 1 };
        maxTalentLevels = new[] { 100, 50, 50, 10, 100, 10, 100, 50, 1, 1, 1, 1, 1 };

        talentNames = new[] { /* ActiveTree */ "Happy Feet", "Merchandising", "Happier Feet", "Improved Merchandising", "Happiest Feet", "Happierest Feet", "More Moneyz", "Doubler Currency", "Doubler XP",
            /* PassiveTree */ "Passive 1", "PConnector 1", /* EconomyTree */ "Economy 1", "EConnector 1" };
        talentDescription = new[]
        {
            //ActiveTree
            "Increase amount gained by clicking (0.1W/s)",
            "Increase length of time clicker frenzy lasts (1s more)",
            "Gain a percentage of passive income per click",
            "Increase multiplication value for clicker frenzy (1x more each upgrade)",
            "Multiply amount gained by clicking (1x more each upgrade)",
            "Multiply amount gained by clicking (10x more each upgrade)",
            "Increase amount gained when watching an ad (+10 minutes of passive income)",
            "Increase time double currency is active",
            "Increase time double xp is active",

            //PassiveTree
            "Passive 1 stuff",
            "PConnector 1 stuff",

            //EconomyTree
            "Economy 1 stuff",
            "EConnector 1 stuff"
        };

        foreach(var talent in talentHolder.GetComponentsInChildren<Talent>())
        {
            talentList.Add(talent);
        }

        foreach (var connector in connectorHolder.GetComponentsInChildren<RectTransform>())
        {
            connectorList.Add(connector.gameObject);
        }

        for (int i = 0; i < talentList.Count; i++)
        {
            talentList[i].ID = i;
        }

        //Active Talent Connections
        talentList[0].connectedTalents = new[] { 1, 2 };
        talentList[1].connectedTalents = new[] { 3, 6 };
        talentList[2].connectedTalents = new[] { 4 };
        talentList[4].connectedTalents = new[] { 5 };
        talentList[6].connectedTalents = new[] { 7 };
        talentList[7].connectedTalents = new[] { 8 };

        //Passive Talent Connections

        //Economy Talent Connections

        UpdateAllTalentUI();
    }

    public void UpdateAllTalentUI()
    {
        foreach(var talent in talentList)
        {
            talent.UpdateUI();
        }
    }
}
