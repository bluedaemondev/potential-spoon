using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitInfo : MonoBehaviour
{
    public int requiredConnections = 4;
    int currentConnections = 0;

    public void AddConnectionToTotal()
    {
        this.currentConnections++;
        if(currentConnections >= requiredConnections)
        {
            Debug.Log(currentConnections);
            FindObjectOfType<AcceptCircuit>().MarkAsDone();
        }
    }
}
