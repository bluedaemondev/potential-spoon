using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRangeInTextUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI textComp;
    [Header("Param to use")]
    public bool useAnxietyLevel;
    public bool useSelfAwarenessLevel;
    public bool useHealthLevel;


    [Space]
    [Header("Rangos")]
    public float dangerFloor = 85;
    public float highFloor = 70;
    public float mediumFloor = 30;
    public float minFloor = 0;




    private void Start()
    {
        this.textComp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void UpdateStatus()
    {
        string res = "";
        float valComp = 0;

        if (useAnxietyLevel)
            valComp = PlayerController.instance.anxietyLevelCurrent;
        else if (useSelfAwarenessLevel)
            valComp = PlayerController.instance.selfAwarenesLevelCurrent;
        else
            valComp = PlayerController.instance.healthLevelCurrent;

        if (useAnxietyLevel || useSelfAwarenessLevel)
        {

            if (valComp >= dangerFloor)
            {
                res = "DANGER!";
            }
            else if (valComp >= highFloor)
            {
                res = "High :C";
            }
            else if (valComp >= mediumFloor)
            {
                res = "Medium";
            }
            else
            {
                res = "Chillin\'";
            }
        }
        else
        {
            if (valComp <= dangerFloor)
            {
                res = "DANGER!";

            }
            else if (valComp <= highFloor)
            {
                res = "High risk :C";
            }
            else if (valComp <= mediumFloor)
            {
                res = "Medium risk :|";
            }
            else
            {
                res = "Chillin\'";
            }
        }

        this.textComp.text = res;

    }
}
