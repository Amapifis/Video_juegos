using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LLAVES : MonoBehaviour
{
    // Start is called before the first frame update
    public int llaves;
    public Text textoLlaves;
    void Start()
    {
        tLlaves();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("LLAVES"))
        {
            llaves = llaves + 1;
            tLlaves();
            Destroy(col.gameObject);
        }
    }

    void tLlaves()
    {
        textoLlaves.text = "Llaves: " + llaves.ToString();
    }
}
