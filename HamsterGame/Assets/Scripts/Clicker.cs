using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Main currency;

    private GameObject background;

    private float targetTime;

    private float clickAmount;

    private float multiplier = 1f;

    private void Start()
    {
        currency = GameObject.Find("GameHandler").GetComponent<Main>();

        background = GameObject.Find("Background");
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
        float tapValue = 1f;

        return tapValue;
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
        background.GetComponent<SpriteRenderer>().color = Color.blue;

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

                    background.GetComponent<SpriteRenderer>().color = Color.cyan;

                    if (clickAmount >= 100)
                    {
                        multiplier = 3f;

                        background.GetComponent<SpriteRenderer>().color = Color.green;

                        if (clickAmount >= 200)
                        {
                            multiplier = 4f;

                            background.GetComponent<SpriteRenderer>().color = Color.yellow;

                            if (clickAmount >= 300)
                            {
                                multiplier = 5f;

                                background.GetComponent<SpriteRenderer>().color = Color.magenta;
                            }
                        }
                    }
                }
            }
        }
    }
}
