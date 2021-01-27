using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitControl : MonoBehaviour
{
    public static CircuitControl instance { get; private set; }

    public List<GameObject> prefabsTablero;

    public CircuitInfo currentCircuit;


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
}
