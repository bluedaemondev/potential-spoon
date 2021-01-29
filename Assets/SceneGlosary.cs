using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlosary : MonoBehaviour
{

    public static SceneGlosary instance { get; private set; }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void LoadScene(string sName)
    {
        SceneManager.LoadScene(SceneManager.GetSceneByPath(sName).buildIndex);
    }

    void LoadScene(int bIdx, bool save=true)
    {
        if(save) { 
        PlayerPrefs.SetFloat("prodScore",
            FindObjectOfType<ProductivityScoreUI>().currentScore);

        PlayerPrefs.SetFloat("anxiety",
            PlayerController.instance.anxietyLevelCurrent);

        PlayerPrefs.SetFloat("selfAw",
            PlayerController.instance.selfAwarenesLevelCurrent);

        PlayerPrefs.SetFloat("health",
            PlayerController.instance.healthLevelCurrent);
        }

        SceneManager.LoadScene(bIdx);
    }

    public void AnxietyEnding()
    {
        LoadScene(2);
    }

    public void DeadEnding()
    {
        LoadScene(3);
    }
    public void CitizenScoreZeroEnding()
    {
        LoadScene(4);
    }

    public void TrueEnding()
    {
        LoadScene(5);
    }

    public void GameMainScene()
    {
        LoadScene(1, false);

    }



}
