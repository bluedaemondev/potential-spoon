using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    public string animAlarm1Trigger = "alarm";
    public AudioClip clipAlarmSingleBeep;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public void BeepAlarm()
    {
        animator.SetTrigger(animAlarm1Trigger);


    }
    public void ResetTrigg()
    {
        animator.ResetTrigger(animAlarm1Trigger);
    }
    public void PlaySound()
    {
        AudioManager.instance.PlayEffect(clipAlarmSingleBeep);
    }
}
