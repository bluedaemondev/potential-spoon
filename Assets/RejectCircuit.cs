using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectCircuit : MonoBehaviour
{
    [Header("audios")]
    public AudioClip clipMarkAsDone;
    public int factorReject = 1;

    //[Space]


    // Start is called before the first frame update
    void Start()
    {

    }
    void OnMouseUp()
    {
        //CircuitControl.instance.LoadNewCircuit();
        CircuitControl.instance.currentCircuit.transform.parent.GetComponent<Animator>().SetTrigger("exit"); // lo elimino por animacion
        CircuitControl.instance.AddQtyToTotals(-1 * factorReject);
        factorReject *= 5;

        AudioManager.instance.PlayEffect(clipMarkAsDone);


    }

}
