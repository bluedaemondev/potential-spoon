using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    //pos inicial del cable
    Vector3 startPoint;
    public SpriteRenderer wireEnd;
    public GameObject lightOn;


    public char index; // a, b, c, d


    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;    
    }

    private void OnMouseDown()
    {
        startPoint = transform.parent.position;
    }

    void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;

        // chequeo si estoy sobre un cable para conectar
        Collider2D[] cols = Physics2D.OverlapCircleAll(newPos, .2f);
        foreach(var col in cols)
        {
            if(col.gameObject != gameObject)
            {
                // snap al otro cable
                UpdateWireGraphic(col.transform.position);

                // chequeo el indice
                if(col.GetComponent<Wire>().index == this.index)
                {
                    col.GetComponent<Wire>()?.Done();
                    Done();
                    FindObjectOfType<CircuitInfo>().AddConnectionToTotal();

                }

                return;
            }
        }
        UpdateWireGraphic(newPos);
        
    }
    private void OnMouseUp()
    {
        UpdateWireGraphic(startPoint);
    }

    void Done()
    {
        lightOn.SetActive(true);
        Destroy(this);
    }

    void UpdateWireGraphic(Vector3 newPos)
    {

        transform.position = newPos;
        var direction = newPos - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPos);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
