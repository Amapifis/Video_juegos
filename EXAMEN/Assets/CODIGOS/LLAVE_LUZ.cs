using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLAVE_LUZ : MonoBehaviour
{
    public Light luz;

    private void Start()
    {
        luz.enabled = false;
    }
    void OnTriggerEnter()
    {
        luz.enabled = true;
    }

}
