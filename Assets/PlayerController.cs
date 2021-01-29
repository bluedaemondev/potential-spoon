using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    // Parametros publicos
    public float healthLost = 10f;
    public float anxietyLost = 10f;
    public float selfAwarenessLost = 10f;


    // Coleccion de componentes 
    public float anxietyLevelCurrent = 0f;
    public const float anxietyLevelMax = 100f;

    

    public float selfAwarenesLevelCurrent = 0f;
    public const float selfAwarenesLevelMax = 100f;

    public float healthLevelCurrent = 100f;
    public const float healthLevelMax = 100f;

    // herramientas

    private float currentTimer = 0;
    public float resetTimerAt = 10f;



    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }



    // al final del frame, actualizo la informacion del personaje y mando un aviso para recargar ui
    void LateUpdate()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer < resetTimerAt)
            return;

        currentTimer = 0;

        UpdateStats(-healthLost, anxietyLost, selfAwarenessLost);
        
        //anxietyLevelCurrent += anxietyLost;
        //selfAwarenesLevelCurrent += selfAwarenessLost;
        //healthLevelCurrent -= healthLost;

        if (anxietyLevelCurrent >= 100 || selfAwarenesLevelCurrent >= 100 ||
            healthLevelCurrent <= 0)
        {
            HandlePlayerLose();
        }


    }
    public void UpdateStats(float healthGiven, float anxietyG, float selfAwarG)
    {
        this.healthLevelCurrent += healthGiven;
        this.anxietyLevelCurrent += anxietyG;
        this.selfAwarenesLevelCurrent += selfAwarG;

        Debug.Log("Updating H,A,S ...  " +
            healthLevelCurrent.ToString() + " , " +
            anxietyLevelCurrent.ToString() + " , " +
            selfAwarenesLevelCurrent.ToString());

        this.healthLevelCurrent = FloorStat(healthLevelCurrent);
        this.anxietyLevelCurrent = FloorStat(anxietyLevelCurrent);
        this.selfAwarenesLevelCurrent = FloorStat(selfAwarenesLevelCurrent);

        Debug.Log("Clamped H,A,S ...  " +
           healthLevelCurrent.ToString() + " , "+
           anxietyLevelCurrent.ToString() + " , " +
           selfAwarenesLevelCurrent.ToString());

        //update ui
        UpdateUI();

    }

    private float FloorStat(float level)
    {
        if (level <= 0)
            level = 0;
        else if (level > 100)
            level = 100;

        return level;
    }

    void UpdateUI()
    {

        FloatRangeInTextUI[] uiMarkers = FindObjectsOfType<FloatRangeInTextUI>();
        foreach(var marker in uiMarkers)
        {
            marker.UpdateStatus();
        }

        //FindObjectOfType<DebugUI>().SetValueForText("anx " + anxietyLevelCurrent + ". saw " + selfAwarenesLevelCurrent + ". hlth " + healthLevelCurrent);


    }
    void HandlePlayerLose()
    {
        if(anxietyLevelCurrent >= 100)
        {
            SceneGlosary.instance.AnxietyEnding();

        }
        if (selfAwarenesLevelCurrent >= 100)
        {
            SceneGlosary.instance.AnxietyEnding();

        }
        if (healthLevelCurrent <= 0)
        {
            SceneGlosary.instance.DeadEnding();

        }
    }
}
