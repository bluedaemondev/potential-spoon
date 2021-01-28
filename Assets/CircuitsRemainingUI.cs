using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitsRemainingUI : MonoBehaviour
{

    TMPro.TextMeshProUGUI textComp;

    private void Start()
    {
        this.textComp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void NewTotal(int number)
    {
        var calculateRemaining = CircuitControl.instance.requiredCircuits - number;
        this.textComp.text = (calculateRemaining + " circuits remaining");

    }
}
