using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    public float cooldownFactor = 5f; //0.005 - 0.1 

    public float healthGiven = -10;
    public float anxietyGiven = -10;
    public float selfAwarenessGiven = 10;

    public bool available = true;

    SpriteRenderer sprrend;
    GameObject maskCd;


    //public float selfAwareness 

    //// Start is called before the first frame update
    void Start()
    {
        sprrend = GetComponent<SpriteRenderer>();
        maskCd = transform.GetChild(0).gameObject;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnMouseUp()
    {
        if (available)
        {
            PlayerController.instance.UpdateStats(healthGiven, anxietyGiven, selfAwarenessGiven);
            StartCoroutine(Cooldown(cooldownFactor));
        }
    }

    IEnumerator Cooldown(float t)
    {
        available = false;
        sprrend.color = Color.grey;

        maskCd.transform.localScale = Vector3.one * 0.8f; // mascara chica
        float currTimer = 0;
        


        while (maskCd.transform.localScale.x < 8)
        {
            maskCd.transform.localScale += Vector3.one * cooldownFactor;
            currTimer += Time.deltaTime;
            //Debug.Log(currTimer);
            yield return null;
        }

        sprrend.color = Color.white;
        available = true;

    }
}
