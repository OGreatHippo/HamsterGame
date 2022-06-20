using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Upgrade : MonoBehaviour
{
    private Main main;

    private Clicker clicker;

    [SerializeField] private int ID;

    [SerializeField] private float price;

    private int amount;

    [SerializeField] private GameObject buttonText;

    private TextMeshProUGUI buyText;

    [SerializeField] private GameObject amountObj;

    private TextMeshProUGUI amountText;

    private void Start()
    {
        main = GameObject.Find("GameHandler").GetComponent<Main>();

        clicker = GameObject.Find("ClickSprite").GetComponent<Clicker>();

        amountText = amountObj.GetComponent<TextMeshProUGUI>();

        buyText = buttonText.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(main.GetCurrency() >= price)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }

        buyText.text = price + " Watts";
        amountText.text = amount.ToString();
    }

    public void buyUpgrade()
    {
        main.SetCurrency(-price);

        addFunction();

        amount += 1;

        price += price * 0.2f;

        price = Mathf.Round(price * 100f) / 100f;
    }

    private void addFunction()
    {
        if(ID == 1)
        {
            clicker.SetClickValue(1f);
        }

        if (ID == 2)
        {
             main.SetPassiveIncome(0.1f);
        }

        if (ID == 3)
        {
            main.SetPassiveIncome(1f);
        }

        if (ID == 4)
        {
            main.SetPassiveIncome(10f);
        }
    }
}
