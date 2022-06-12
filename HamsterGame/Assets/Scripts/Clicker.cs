using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Main currency;

    private Animator multiplierText;

    private float targetTime;

    private float clickAmount;

    private float tapValue = 1f;

    private float multiplier = 1f;

    private void Start()
    {
        currency = GameObject.Find("GameHandler").GetComponent<Main>();

        multiplierText = GameObject.Find("multiplierText").GetComponent<Animator>();
    }

    private void Update()
    {
        updateMultiplier();
    }

    private void OnMouseDown()
    {
        StartCoroutine(clickAnimation());
    }

    private float clickingValue()
    {
        return tapValue;
    }

    public float SetClickValue(float increase)
    {
        return tapValue += increase;
    }
    public float getMultiplier()
    {
        return multiplier;
    }

    private IEnumerator clickAnimation()
    {
        currency.SetCurrency(clickingValue() * multiplier);

        clickAmount += 1f;

        gameObject.transform.localScale = gameObject.transform.localScale * 1.5f;

        yield return new WaitForSeconds(0.1f);

        gameObject.transform.localScale = gameObject.transform.localScale / 1.5f;

        targetTime = 3f;
    }

    private void endTimer()
    {
        multiplierText.SetBool("animate", false);

        multiplier = 1f;

        clickAmount = 0f;
    }

    private void updateMultiplier()
    {
        if (clickAmount >= 1)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                endTimer();
            }
            else
            {
                if (clickAmount >= 50)
                {
                    multiplier = 2f;

                    multiplierText.SetBool("animate", true);

                    if (clickAmount >= 100)
                    {
                        multiplier = 3f;

                        if (clickAmount >= 200)
                        {
                            multiplier = 4f;

                            if (clickAmount >= 300)
                            {
                                multiplier = 5f;
                            }
                        }
                    }
                }
            }
        }
    }
}
