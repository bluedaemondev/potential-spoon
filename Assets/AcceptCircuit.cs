using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptCircuit : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}
    [Header("audios")]
    public AudioClip clipMarkAsDone;
    public AudioClip clipRejectInput;


    [Space]
    public SpriteRenderer sprrend;


    public Color readyToSendColor;
    public Color notReadyToSendColor;

    public bool available = false;

    private void Start()
    {
        sprrend = GetComponent<SpriteRenderer>();
        sprrend.color = notReadyToSendColor;
    }

    void OnMouseUp()
    {
        if (available)
        {
            //CircuitControl.instance.LoadNewCircuit();
            CircuitControl.instance.currentCircuit.transform.parent.GetComponent<Animator>().SetTrigger("exit"); // lo elimino por animacion
            sprrend.color = notReadyToSendColor;
            CircuitControl.instance.AddQtyToTotals(1);

            FindObjectOfType<MessagePusher>().PlayGoodPushNotif();

            available = false;
        }
        else
        {
            AudioManager.instance.PlayEffect(clipRejectInput);
        }
    }

    // evento de feedback para mostrar que puedo entregar el tablero ?
    public void MarkAsDone()
    {
        sprrend.color = readyToSendColor;
        AudioManager.instance.PlayEffect(clipMarkAsDone);
        available = true;


    }
}
