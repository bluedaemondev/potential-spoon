using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitControl : MonoBehaviour
{
    public static CircuitControl instance { get; private set; }

    public List<GameObject> prefabsTablero;

    public CircuitInfo currentCircuit;

    [Header("Rechazar = -1 , Aprobar = 1")]
    public int qtyCircuits = 0;
    [Header("Maximo de circuitos para final CitizenScore")]
    public int maxQtyCircuitsCitizen = 1028;

    [Header("Condicion de victoria")]
    public int requiredCircuits = 512;





    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
            instance = this;

        currentCircuit = FindObjectOfType<CircuitInfo>();
        // debe haber un circuito instanciado al iniciar
    }
    public void LoadNewCircuit()
    {
        int idxNewPrefab = 0;

        if (prefabsTablero.Count > 1)
        {
            idxNewPrefab = Random.Range(0, prefabsTablero.Count);

        }


        var newCircuit = Instantiate(prefabsTablero[idxNewPrefab], new Vector3(0, -1.866156f,0) ,Quaternion.identity, transform);
        //newCircuit.name = "TableroBase";
        currentCircuit = newCircuit.transform.GetChild(0).GetComponent<CircuitInfo>();

        currentCircuit.transform.localPosition = Vector3.zero;

        //currentCircuit.transform.parent.GetComponent<Animator>().Play("tableroEntrada"); // lo inicializo por animacion
    }

    public void AddQtyToTotals(int number)
    {
        this.qtyCircuits += number;
        
        FindObjectOfType<CircuitsRemainingUI>().NewTotal(this.qtyCircuits);
        FindObjectOfType<ProductivityScoreUI>().CalcTotal(number);

        if(number < 0)
        {
            FindObjectOfType<LampScript>().BeepAlarm();
        }

        //if (this.qtyCircuits >= requiredCircuits &&
        //    FindObjectOfType<ProductivityScoreUI>().currentScore >= 10)
        if (this.qtyCircuits >= requiredCircuits)
        { 
            SceneGlosary.instance.TrueEnding();
        }
        if (qtyCircuits >= maxQtyCircuitsCitizen ||
            FindObjectOfType<ProductivityScoreUI>().currentScore < 1)
        {
            SceneGlosary.instance.CitizenScoreZeroEnding();
        }
    }
}
