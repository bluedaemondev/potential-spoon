using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    //public GameObject lightBlinker;
    Animator animator;

    public string blinkParam = "blink";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void BlinkLight()
    {
        animator.SetTrigger(blinkParam);
    }
    public void ResetTriggBlink()
    {
        animator.ResetTrigger(blinkParam);
    }

}
