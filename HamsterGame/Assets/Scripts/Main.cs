using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private GameObject currencyText;
    private GameObject multiplierText;

    private Clicker clicker;

    [SerializeField] private GameObject upgradeMenu;

    private float currencyValue;

    [SerializeField] private float passiveIncome;

    [SerializeField] private float targetTime = 1f;

    [SerializeField] private float passiveMultiplier = 1f;

    private void Start()
    {
        currencyText = GameObject.Find("currencyText");

        clicker = GameObject.Find("ClickSprite").GetComponent<Clicker>();

        multiplierText = currencyText.transform.Find("multiplierText").gameObject;
    }

    private void Update()
    {
        currencyText.GetComponent<Text>().text = currencyValue + " Watts Generated";

        multiplierText.GetComponent<Text>().text = "x" + clicker.getMultiplier();

        addIncome();
    }

    public float SetCurrency(float increase)
    {
        return currencyValue += increase;
    }

    public float GetCurrency()
    {
        return currencyValue;
    }

    public float SetPassiveIncome(float increase)
    {
        return passiveIncome += increase;
    }

    public float SetMultiplierValue(float increase)
    {
        return passiveMultiplier += increase;
    }

    public void openUpgradeMenu()
    {
        if (upgradeMenu != null)
        {
            bool isActive = upgradeMenu.activeSelf;

            upgradeMenu.SetActive(!isActive);
        }
    }

    private void addIncome()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            currencyValue += passiveIncome * passiveMultiplier;

            targetTime = 1f;
        }
    }
}
