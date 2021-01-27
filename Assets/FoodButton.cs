using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    public float healthGiven = 10;
    //public float selfAwareness 

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnMouseUp()
    {
        PlayerController.instance.UpdateStats(healthGiven, 0, 0);
    }
}
