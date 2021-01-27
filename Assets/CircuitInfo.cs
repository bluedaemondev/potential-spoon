using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitInfo : MonoBehaviour
{
    public int requiredConnections = 4;
    int currentConnections = 0;

    void AddConnectionToTotal()
    {
        this.currentConnections++;
        if(currentConnections >= requiredConnections)
        {
            FindObjectOfType<AcceptCircuit>().MarkAsDone();
        }
    }
}
