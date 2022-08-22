using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager buildingManager;

    public Main currency;

    public Clicker clicker;

    public float[] cost;
    public string[] buildingNames;
    public string[] buildingDescription;
    public int[] currentAmount;

    public List<Upgrade> buildingList;
    public GameObject buildingHolder;

    private void Awake()
    {
        buildingManager = this;
    }

    private void Start()
    {
        currency = GameObject.Find("GameHandler").GetComponent<Main>();

        cost = new[] { 5f, 20f, 50f, 100f, 200f, 500f, 1000f, 2000f, 5000f, 10000f, 20000f, 50000f, 100000f, 200000f, 500000f, 1000000f, 2000000f, 5000000f, 10000000f, 100000000f };
        currentAmount = new int[20];

        buildingNames = new[] { "Hamster Food", "Spare Hamsters", "Oiled Wheels", "Super Serum", "Upgrade 5", "Upgrade 6", "Upgrade 7", "Upgrade 8", "Upgrade 9", "Upgrade 10"
        , "Upgrade 11", "Upgrade 12", "Upgrade 13", "Upgrade 14", "Upgrade 15", "Upgrade 16", "Upgrade 17", "Upgrade 18", "Quantum Hamsters", "Pocket Dimension"};
        buildingDescription = new[]
        {
            "Feed your hamster food and increase amount gained per click. (+0.1WPS)",
            "Buy Spare Hamsters to generate passive income. (+0.5WPS)",
            "Oil the wheels making it easier for the hamsters run. (+1WPS)",
            "Give the Hamsters Super Serum increasing passive income. (+5WPS)",
            "Upgrade 5(+10WPS)",
            "Upgrade 6(+50WPS)",
            "Upgrade 7(+100WPS)",
            "Upgrade 8(+500WPS)",
            "Upgrade 9(+1000WPS)",
            "Upgrade 10(+5000WPS)",
            "Upgrade 11(+10000WPS)",
            "Upgrade 12(+50000WPS)",
            "Upgrade 13(+100000WPS)",
            "Upgrade 14(+500000WPS)",
            "Upgrade 15(+1000000WPS)",
            "Upgrade 16(+5000000WPS)",
            "Upgrade 17(+10000000WPS)",
            "Upgrade 18(+50000000WPS)",
            "Shrink Hamsters to the Quantum Realm. (+100000000WPS)",
            "Create a Pocket Dimension for unlimited Hamster Power! (+1000000000WPS)"
        };

        foreach (var building in buildingHolder.GetComponentsInChildren<Upgrade>())
        {
            buildingList.Add(building);
        }

        for (int i = 0; i < buildingList.Count; i++)
        {
            buildingList[i].ID = i;
        }

        UpdateAllBuildingUI();
    }

    public void UpdateAllBuildingUI()
    {
        foreach (var building in buildingList)
        {
            building.UpdateUI();
        }
    }
}
