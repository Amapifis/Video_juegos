using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PUERTA : MonoBehaviour
{
    public Light llaveamarilla;
    public Light llaveRoja;
    public Light llaveAzul;

    public GameObject pivotePuerta;

    void Start()
    {
        pivotePuerta = GameObject.Find("PIVOTE_PUERTA");
    }
    void OnTriggerEnter()
    {
        if (llaveamarilla.enabled == true & llaveRoja.enabled == true & llaveAzul.enabled == true)
        {
            pivotePuerta.GetComponent<Animator>().SetBool("OPEN",true);
        }
    }
}
