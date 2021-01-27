using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptCircuit : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}
    public SpriteRenderer sprrend;


    public Color readyToSendColor;
    public Color notReadyToSendColor;

    private void Start()
    {
        sprrend = GetComponent<SpriteRenderer>();
        sprrend.color = notReadyToSendColor;
    }

    void OnMouseUp()
    {
        CircuitControl.instance.currentCircuit.transform.parent.GetComponent<Animator>().SetTrigger("exit"); // lo elimino por animacion

        //CircuitControl.instance.LoadNewCircuit();
        sprrend.color = notReadyToSendColor;

    }

    // evento de feedback para mostrar que puedo entregar el tablero ?
    public void MarkAsDone()
    {
        sprrend.color = readyToSendColor;


    }
}
