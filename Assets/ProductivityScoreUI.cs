using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityScoreUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI textComp;

    [Range(0, 10)]
    public float currentScore = 10;

    public bool comboRejection = false;
    public int countRejections = 0;

    private void Start()
    {
        this.textComp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void CalcTotal(int lastActionQty)
    {
        if (lastActionQty < 0)
        {
            comboRejection = true;
            countRejections++;

            currentScore -= 0.5f;
        }
        else
        {
            comboRejection = false;

            // para cappear los limites

            if (countRejections - 1 <= 0)
                countRejections = 0;
            else
            {
                countRejections--;
                if (currentScore + 0.25f <= 10)
                    currentScore += 0.25f;
                else
                    currentScore = 10;
            }

        }

        currentScore = Mathf.Abs(currentScore);

        this.textComp.text = ("Productivity score " + System.String.Format("{0:0.0}", currentScore));

    }
}
