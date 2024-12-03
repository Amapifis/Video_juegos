using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MONEDAS : MonoBehaviour
{
    [Header("Variables Numericas")]
    public int coins;
    public Text textoCoins;

    [Header("Variables Sonido")]
    public AudioSource equipoMusica;
    public AudioClip sonidoCoins;
    void Start()
    {
        tCoins();
        equipoMusica = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("COINS"))
        {
            coins = coins + 1;
            equipoMusica.PlayOneShot(sonidoCoins);
            tCoins();
            Destroy(col.gameObject);
        }
    }

    void tCoins()
    {
        textoCoins.text ="Monedas: " + coins.ToString();
    }
}
