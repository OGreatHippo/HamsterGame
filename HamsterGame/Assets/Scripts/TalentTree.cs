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

        currentTalentLevels = new int[16];
        talentCost = new[] { 1, 1, 1, 10, 1, 100, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        maxTalentLevels = new[] { 100, 50, 50, 10, 100, 10, 100, 50, 1, 100, 100, 50, 50, 1, 1, 1 };

        talentNames = new[] { /* ActiveTree */ "Happy Feet", "Merchandising", "Happier Feet", "Improved Merchandising", "Happiest Feet", "Happierest Feet", "More Moneyz", "Doubler Currency", "Doubler XP",
            /* PassiveTree */ "Improved Passive Income", "Experienced Hamsters", "Passive Income#", "Passive Income++", "Offline Time", "Offline Income", /* EconomyTree */ "Economy 1", "EConnector 1" };
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
            "Increase passive income by 0.1x",
            "Increase XP generation (1xp/s)",
            "Increase passive income by 1x",
            "Increase passive income by 5x",
            "Increase amount of time you generate income while offline (+10 mins)",
            "Increase percentage of passive income while offline (+1%)",

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
        talentList[9].connectedTalents = new[] { 10 };
        talentList[10].connectedTalents = new[] { 11, 12 };
        talentList[11].connectedTalents = new[] { 13 };
        talentList[12].connectedTalents = new[] { 14 };
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
