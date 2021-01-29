using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListStepOnClick : MonoBehaviour
{
    [Header("Paneles o imagenes en secuencia")]
    public List<GameObject> goList;

    public int currIdx;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currIdx >= 0 && currIdx < goList.Count-1)
                goList[currIdx].SetActive(false);

            currIdx++;

            if (currIdx >= goList.Count)
                goList[goList.Count - 1].SetActive(true);
            else
                goList[currIdx].SetActive(true);
            
        }
    }
}
