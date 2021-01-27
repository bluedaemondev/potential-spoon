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

}
