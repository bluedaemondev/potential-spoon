using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    [Range(0, 1)]
    public float cooldownFactor = 0.3f; //0.005 - 0.1 

    public float healthGiven = -10;
    public float anxietyGiven = -10;
    public float selfAwarenessGiven = 10;

    public int circuitsGiven = 0;

    public bool available = true;

    SpriteRenderer sprrend;
    GameObject maskCd;

    Color startColor;

    //// Start is called before the first frame update
    void Start()
    {
        sprrend = GetComponent<SpriteRenderer>();
        maskCd = transform.GetChild(0).gameObject;
        startColor = sprrend.color;
    }

    private void OnMouseEnter()
    {
        string statsInt = CalcStringToDisplay();
        FindObjectOfType<PanelInfoUI>().SetVisiblePanelStats(statsInt);

    }
    private void OnMouseExit()
    {
        FindObjectOfType<PanelInfoUI>().DisablePanel();
    }

    private string CalcStringToDisplay()
    {
        string result = "Anx " + (anxietyGiven > 0 ? "+" : "") + this.anxietyGiven + "\n";
        result += "S.Awr " + (selfAwarenessGiven > 0 ? "+" : "") + this.selfAwarenessGiven + "\n";
        result += "Hlth " + (healthGiven > 0 ? "+": "" ) + this.healthGiven + "\n";

        result += "Circuits " + (circuitsGiven > 0 ? "-" : "") + this.circuitsGiven;

        return result;
    }

    ///// <summary>
    ///// Devuelve "+", "++" , "+++"
    ///// o -
    ///// </summary>
    ///// <param name="input"></param>
    ///// <returns></returns>
    //public string NumberSigns(float input)
    //{

    //}


    private void OnMouseUp()
    {
        if (available)
        {
            PlayerController.instance.UpdateStats(healthGiven, anxietyGiven, selfAwarenessGiven);
            CircuitControl.instance.AddQtyToTotals(circuitsGiven);

            StartCoroutine(Cooldown(cooldownFactor));
        }
    }

    IEnumerator Cooldown(float t)
    {
        available = false;
        sprrend.color = Color.grey;

        maskCd.transform.localScale = Vector3.one * 0.1f; // mascara chica
        float currTimer = 0;



        while (maskCd.transform.localScale.x < 1.1f)
        {
            maskCd.transform.localScale += Vector3.one * cooldownFactor;
            currTimer += Time.deltaTime;
            //Debug.Log(currTimer);
            yield return null;
        }

        sprrend.color = startColor;
        available = true;

    }
}
