using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private GameObject currencyText;
    private GameObject multiplierText;

    private Clicker clicker;

    private Animator multiplierAnimation;

    [SerializeField] private GameObject upgradeMenu;

    private float currencyValue;
    private float targetTime;


    private void Start()
    {
        currencyText = GameObject.Find("currencyText");

        clicker = GameObject.Find("ClickSprite").GetComponent<Clicker>();

        multiplierText = currencyText.transform.Find("multiplierText").gameObject;

        multiplierAnimation = multiplierText.GetComponent<Animator>();
    }

    private void Update()
    {
        currencyText.GetComponent<Text>().text = currencyValue + " Watts Generated";

        multiplierText.GetComponent<Text>().text = "x" + clicker.getMultiplier();

        if (clicker.getMultiplier() > 1f)
        {
            animateMultiplier();
        }
    }

    private void animateMultiplier()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            multiplierAnimation.Play("multiplierAnim");
        }
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
