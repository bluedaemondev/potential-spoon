using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectCircuit : MonoBehaviour
{
    [Header("audios")]
    public AudioClip clipMarkAsDone;

    //[Space]


    // Start is called before the first frame update
    void Start()
    {

    }
    void OnMouseUp()
    {
        //CircuitControl.instance.LoadNewCircuit();
        CircuitControl.instance.currentCircuit.transform.parent.GetComponent<Animator>().SetTrigger("exit"); // lo elimino por animacion
        AudioManager.instance.PlayEffect(clipMarkAsDone);

    }
}
