using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class FIN_VIDEO : MonoBehaviour
{
    


   
    void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {

            SceneManager.LoadScene("FIN");

             }
    }
    

    // Update is called once per frame
   
}
