using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private GameObject currencyText;
    [SerializeField] private GameObject upgradeMenu;

    private float currencyValue;

    private bool pressed = false;

    private void Start()
    {
        currencyText = GameObject.Find("currencyText");
    }

    private void Update()
    {
        currencyText.GetComponent<Text>().text = currencyValue + " Watts Generated";
    }

    public float SetCurrency(float increase)
    {
        return currencyValue += increase;
    }

    public void openUpgradeMenu()
    {
        if (upgradeMenu != null)
        {
            bool isActive = upgradeMenu.activeSelf;

            upgradeMenu.SetActive(!isActive);
        }
    }

    public void buyUpgrade(int id, float cost, int amount)
    {

    }
}
