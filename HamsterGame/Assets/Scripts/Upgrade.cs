using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private Main main;

    private Clicker clicker;

    [SerializeField] private int ID;

    [SerializeField] private int tier;

    [SerializeField] private float price;

    [SerializeField] private int amount;

    private int currentAmount;

    [SerializeField] private Text title;

    [SerializeField] private Text description;

    [SerializeField] private Text buyText;

    [SerializeField] private Text amountText;

    [SerializeField] private string titleText;

    [SerializeField] private string descriptionText;

    [SerializeField] private GameObject upgradeButton;

    [SerializeField] private GameObject completeImage;


    private void Start()
    {
        main = GameObject.Find("GameHandler").GetComponent<Main>();

        clicker = GameObject.Find("ClickSprite").GetComponent<Clicker>();

        description.text = descriptionText;

        title.text = titleText;
    }

    private void Update()
    {
        if(main.GetCurrency() >= price)
        {
            upgradeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            upgradeButton.GetComponent<Button>().interactable = false;
        }

        if(currentAmount == amount)
        {
            upgradeButton.SetActive(false);

            completeImage.SetActive(true);
        }

        amountText.text = currentAmount + " / " + amount;
        buyText.text = price + " Watts";
    }

    public void buyUpgrade()
    {
        main.SetCurrency(-price);

        addFunction();

        currentAmount += 1;

        price += price * 2;
    }

    private void addFunction()
    {
        if(ID == 1)
        {
            main.SetPassiveIncome(1f);
        }

        if (ID == 2)
        {
            main.SetMultiplierValue(0.05f);
        }

        if (ID == 3)
        {
            clicker.SetClickValue(1f);
        }
    }
}
