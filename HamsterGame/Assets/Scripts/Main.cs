using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{
    private GameObject currencyText;
    private GameObject wpsText;
    public GameObject rewardButton;
    public Animator rewardAnimation;
    public GameObject canvas;

    public Clicker clicker;

    private bool xpBoostActive = false;

    private bool currencyBoostActive = false;

    public bool frenzyBoostActive = false;

    private int advertType;

    private bool adSpawned = false;

    [SerializeField] private GameObject upgradeMenu;

    [SerializeField] private GameObject buildingMenu;

    [SerializeField] private xpBar xpBar;

    [SerializeField] private GameObject talentTree;

    private float currencyValue = 100000f;

    private float passiveIncome;

    private float passiveMultiplier = 1f;

    private int level = 1;

    private int currentXp;

    private int xpMultiplier = 1;

    private float targetTime = 1f;

    private float advertTime;

    private float currentCurrencyMultiplierTime;

    public float currentFrenzyMultiplierTime;

    public float frenzyMultiplierTime;

    public float currencyMultiplierTime;

    public float xpMultiplierTime;

    private float currentXpMultiplierTime;

    private int maxXp = 300;

    private int talentPoints = 100;

    private Animator buildingAnim;

    private Animator upgradeAnim;

    private TextMeshProUGUI talentText;

    private int frenzyMultplier;

    private int currencyTimer = 3600;

    private void Start()
    {
        InitializeObjects();
        UpdateUIValues();

        //advertType = Random.Range(1, 1000);

        //advertTime = Random.Range(120f, 180f);

        advertType = 900;

        advertTime = Random.Range(1f, 4f);
    }

    private void Update()
    {
        addIncome();
        levelUp();
        SpawnAdvertButton();
        Timers();
        MultiplyCurrency();
        MultiplyXP();
        ClickFrenzy();
    }

    private void InitializeObjects()
    {
        currencyText = GameObject.Find("currencyText");

        currencyText.GetComponent<Text>().text = currencyValue + " Watts Generated";

        wpsText = currencyText.transform.Find("wpsText").gameObject;

        buildingAnim = buildingMenu.GetComponent<Animator>();

        upgradeAnim = upgradeMenu.GetComponent<Animator>();

        talentText = upgradeMenu.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateUIValues()
    {
        xpBar.SetMaxXP(maxXp);

        xpBar.SetXP(currentXp);

        currencyText.GetComponent<Text>().text = currencyValue + " Watts Generated";

        passiveIncome = Mathf.Round(passiveIncome * 100f) / 100f;

        wpsText.GetComponent<Text>().text = passiveIncome * passiveMultiplier + "W/s";

        talentText.text = "Talent Points: " + talentPoints;
    }

    public float SetCurrency(float increase)
    {
        currencyValue += increase;
        currencyValue = Mathf.Round(currencyValue * 100f) / 100f;

        return currencyValue;
    }

    public float GetCurrency()
    {
        return currencyValue;
    }

    public float SetTalents(int increase)
    {
        talentPoints -= increase;

        talentText.text = "Talent Points: " + talentPoints;

        return talentPoints;
    }

    public float GetTalents()
    {
        return talentPoints;
    }

    public float GetPassiveIncome()
    {
        return passiveIncome;
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
            bool isActive = upgradeAnim.GetBool("opened");

            upgradeAnim.SetBool("opened", !isActive);
        }
    }

    public void openBuildingMenu()
    {
        if (buildingMenu != null)
        {
            bool isActive = buildingAnim.GetBool("opened");

            buildingAnim.SetBool("opened", !isActive);
        }
    }

    private void levelUp()
    {
        if (currentXp == maxXp)
        {
            level += 1;

            currentXp = 0;

            xpBar.SetXP(currentXp);

            talentPoints += 1;

            UpdateUIValues();

            if (level == 2)
            {
                maxXp = 3600;

                xpBar.SetMaxXP(maxXp);
            }

            if (level == 3)
            {
                maxXp = 86400;

                xpBar.SetMaxXP(maxXp);
            }

            if (level == 4)
            {
                maxXp = 302400;

                xpBar.SetMaxXP(maxXp);
            }

            if (level >= 5)
            {
                maxXp = 604800;

                xpBar.SetMaxXP(maxXp);
            }
        }
    }

    private void Timers()
    {
        targetTime -= Time.deltaTime;

        currentCurrencyMultiplierTime -= Time.deltaTime;

        currentXpMultiplierTime -= Time.deltaTime;

        currentFrenzyMultiplierTime -= Time.deltaTime;
    }

    private void addIncome()
    {
        if (targetTime <= 0.0f)
        {
            currencyValue += passiveIncome * passiveMultiplier;

            UpdateUIValues();

            currentXp += 1 * xpMultiplier;

            xpBar.SetXP(currentXp);

            targetTime = 1f;
        }
    }

    public void changePage1()
    {
        talentTree.transform.localPosition = new Vector2(0, talentTree.transform.localPosition.y);
    }

    public void changePage2()
    {
        talentTree.transform.localPosition = new Vector2(-5000, talentTree.transform.localPosition.y);
    }

    public void changePage3()
    {
        talentTree.transform.localPosition = new Vector2(-10000, talentTree.transform.localPosition.y);
    }

    public void SpawnAdvertButton()
    {
        if(!adSpawned)
        {
            advertTime -= Time.deltaTime;
        }

        if (advertTime <= 0.0f)
        {
            advertType = Random.Range(1, 1000);

            if (xpBoostActive && advertType <= 1000 && advertType >= 788)
            {
                advertType = 1;
            }

            else if (currencyBoostActive && advertType <= 787 && advertType >= 571)
            {
                advertType = 1;
            }

            else if (frenzyBoostActive && advertType >= 1 && advertType <= 350)
            {
                advertType = 500;
            }

            rewardAnimation.SetBool("spawn", true);

            adSpawned = true;

            advertTime = Random.Range(120f, 180f);
        }
    }

    public void SetBool(bool result)
    {
        adSpawned = result;
    }

    public void advertReward()
    {
        if(advertType <= 1000 && advertType >= 788)
        {
            currentXpMultiplierTime = xpMultiplierTime;
            Debug.Log("double xp");
            MultiplyXP();
            UpdateUIValues();
        }
        else if (advertType <= 787 && advertType >= 571)
        {
            currentCurrencyMultiplierTime = currencyMultiplierTime;
            Debug.Log("double moeny");
            MultiplyCurrency();
            UpdateUIValues();
        }
        else if (advertType <= 570 && advertType >= 351)
        {
            Debug.Log("Money");
            AddCurrency();
            UpdateUIValues();
        }
        else
        {
            currentFrenzyMultiplierTime = frenzyMultiplierTime;
            Debug.Log("Frenzy");
            ClickFrenzy();
            UpdateUIValues();
        }
    }

    private float AddCurrency()
    {
        float reward = 50;

        reward += passiveIncome * currencyTimer;

        return SetCurrency(reward);
    }

    public int SetCurrencyTimer(int increase)
    {
        return currencyTimer += increase;
    }

    private void MultiplyCurrency()
    {
        if (currentCurrencyMultiplierTime > 0)
        {
            currencyBoostActive = true;
            passiveMultiplier = 2f; 
        }

        else
        {
            currencyBoostActive = false;
            passiveMultiplier = 1f;
        }     
    }

    public float SetDoubleCurrencyTime(float time)
    {
        return currencyMultiplierTime += time;
    }

    private int ClickFrenzy()
    {
        if (currentFrenzyMultiplierTime > 0)
        {
            frenzyBoostActive = true;
            return clicker.MultiplierEquals(10);
        }

        else
        {
            frenzyBoostActive = false;
            return clicker.MultiplierEquals(1);
        }
        
    }

    public float SetFrenzyTime(float time)
    {
        return frenzyMultiplierTime += time;
    }

    public int SetFrenzyMultiplier(int multiply)
    {
        return frenzyMultplier += multiply;
    }

    private void MultiplyXP()
    {
        if (currentXpMultiplierTime > 0)
        {
            xpBoostActive = true;
            xpMultiplier = 2;
        }

        else
        {
            xpBoostActive = false;
            xpMultiplier = 1;
        }
    }
    public float SetDoubleXPTime(float time)
    {
        return xpMultiplierTime += time;
    }
}
