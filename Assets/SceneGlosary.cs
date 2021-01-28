using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlosary : MonoBehaviour
{

    public static SceneGlosary instance { get; private set; }

    public GameObject deadEndingGO;
    public GameObject anxietyEndingGO;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void LoadScene(string sName)
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName(sName).buildIndex);
    }

    public void AnxietyEnding()
    {
        LoadScene("anxietyEnding");
    }

    public void DeadEnding()
    {
        LoadScene("deadEnding");
    }
    public void CitizenScoreZeroEnding()
    {
        LoadScene("citizenEnding");
    }

    public void TrueEnding()
    {
        LoadScene("trueEnding");
    }



}
