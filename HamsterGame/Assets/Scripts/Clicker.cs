using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Main main;

    private float tapValue = 1f;

    private int percentage;

    public int multiplier = 1;

    private void Start()
    {
        main = GameObject.Find("GameHandler").GetComponent<Main>();
    }

    private void OnMouseDown()
    {
        StartCoroutine(clickAnimation());
    }

    private float clickingValue()
    {
        return tapValue + main.GetPassiveIncome() / 100 * percentage;
    }

    public float SetClickValue(float increase)
    {
        return tapValue += increase;
    }
    public int GetMultiplier()
    {
        return multiplier;
    }

    public int SetMultiplier(int multiply)
    {
        return multiplier += multiply;
    }

    public int MultiplierEquals(int multiply)
    {
        return multiplier = multiply;
    }

    public int AddPercentagePerClick(int percentageInc)
    {
        return percentage += percentageInc;
    }

    private IEnumerator clickAnimation()
    {
        main.SetCurrency(clickingValue() * multiplier);

        main.UpdateUIValues();

        gameObject.transform.localScale = gameObject.transform.localScale * 1.5f;

        yield return new WaitForSeconds(0.1f);

        gameObject.transform.localScale = gameObject.transform.localScale / 1.5f;
    }
}
