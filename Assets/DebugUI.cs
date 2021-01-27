using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public void SetValueForText(string newStr)
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().text = newStr;
    }
}
