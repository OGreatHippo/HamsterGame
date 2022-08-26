using UnityEngine;
using TMPro;
using System;

public class OfflineProgress : MonoBehaviour
{
    public GameObject earningsPanel;

    public Main main;

    public TextMeshProUGUI earningsText;
    public TextMeshProUGUI timeText;

    private int timeRemaning = 360;

    private int percentageIncome = 50;

    // Start is called before the first frame update
    void Start()
    {
        //if(PlayerPrefs.HasKey("LAST_LOGIN"))
        //{
        //    earningsPanel.SetActive(true);

        //    earningsPanel.GetComponent<Animator>().SetBool("closed", false);

        //    DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LAST_LOGIN"));

        //    TimeSpan ts = DateTime.Now - lastLogin;

        //    float lastWPS = PlayerPrefs.GetFloat("LAST_WPS");

        //    float lastCurrency = PlayerPrefs.GetFloat("LAST_TOTAL");

        //    timeText.text = string.Format("{0} Days, {0} Hours, {0} Minutes, {0} Seconds Ago.", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);

        //    earningsText.text = lastWPS * (int)ts.TotalSeconds + "W";

        //    main.SetCurrency(lastCurrency + lastWPS * (int)ts.TotalSeconds);

        //    main.SetPassiveIncome(lastWPS);
        //}
        //else
        //{
        //    earningsPanel.SetActive(false);
        //}
    }

    public int SetTimeRemaining(int increase)
    {
        return timeRemaning += increase;
    }

    public int SetPercentageIncome(int increase)
    {
        return percentageIncome += increase;
    }

    public void closeEarningsPanel()
    {
        earningsPanel.GetComponent<Animator>().SetBool("closed", true);
    }

    private void OnApplicationQuit()
    {
        //PlayerPrefs.SetString("LAST_LOGIN", DateTime.Now.ToString());
        //PlayerPrefs.SetFloat("LAST_TOTAL", main.GetCurrency());
        //PlayerPrefs.SetFloat("LAST_WPS", main.GetPassiveIncome());
    }
}
