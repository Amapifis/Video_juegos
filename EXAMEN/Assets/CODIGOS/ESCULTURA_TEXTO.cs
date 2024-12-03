using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ESCULTURA_TEXTO : MonoBehaviour
{
    public bool entroPlayer = false;
    public Text textoDialogo;
    public GameObject panelTexto;
    public bool comenzoDialogo;
    public int lineaDialogo;
    public float tiempoTipeoTexto;
    public HEROMOVE Player;
    [TextArea(4,7)]public string[] lineasTextoDialogo;

    void Start()
    {
        panelTexto.SetActive(false);
        Player = GameObject.Find("HERO").GetComponent<HEROMOVE>();
    }

    void Update()
    {
        activarDialogo();
    }

    void activarDialogo()
    {
        if (entroPlayer == true && Input.GetButtonDown("Fire1"))
        {
            if (comenzoDialogo == false) 
            {
                dialogoComenzo();
            }
            else if (textoDialogo.text == lineasTextoDialogo[lineaDialogo])
            {
                siguenteLineaDialogo();
            }
            else
            {
                StopAllCoroutines();
                textoDialogo.text = lineasTextoDialogo[lineaDialogo];
              
               
            }
        }
    }

    void dialogoComenzo()
    {
        comenzoDialogo = true;
        panelTexto.SetActive(true);
        lineaDialogo = 0;
        StartCoroutine(mostrarLineas());

    }

    IEnumerator mostrarLineas()
    {
        textoDialogo.text = string.Empty;

        foreach (char ch in lineasTextoDialogo[lineaDialogo])
        {
            textoDialogo.text += ch;
            yield return new WaitForSeconds(tiempoTipeoTexto);

        }
    }

    void siguenteLineaDialogo()
    {
        lineaDialogo++;
        if (lineaDialogo < lineasTextoDialogo.Length)
        {
            StartCoroutine(mostrarLineas());
        }
        else
        {
            comenzoDialogo = false;
            textoDialogo.text = ""; // Limpia el texto al finalizar
            panelTexto.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.CompareTag("Player"))
    {
           entroPlayer = true;
    }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entroPlayer = false;
            comenzoDialogo = false;
            StopAllCoroutines(); // Detiene cualquier corrutina activa
            textoDialogo.text = ""; // Limpia el texto
            panelTexto.SetActive(false); // Oculta el panel de texto
        }

    }

}
