using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VIDAS : MonoBehaviour
{
    public int vidas;
    public Text textoVidas;
    public Animator anim;
    public HEROMOVE hm;

    public AudioSource equipoMusica;
    public AudioClip sonidoMuerte;
    public GameObject GameMusic;
    void Start()
    {
        tVidas();
        anim = GetComponent<Animator>();
        hm = GameObject.Find("HERO").GetComponent<HEROMOVE>();
        equipoMusica = GetComponent<AudioSource>();
        GameMusic = GameObject.Find("GameMusic");
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ENEMIGO_TRAMPA")) 
        { 
        vidas = vidas - 1;
            tVidas();
        }
        if (vidas <= 0)
        {
            anim.SetTrigger("Death");
            hm.enabled = false;
            StartCoroutine(muerte());
        }
        if (col.gameObject.CompareTag("COMBO"))
        {
            vidas = vidas - 1;
            tVidas();
            if (vidas <= 0)
            {
                StartCoroutine(muerte());
                anim.SetTrigger("Death");
            }
        }
    }

    void tVidas()
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
    }
    IEnumerator muerte()
    {
        Destroy(GameMusic);
        equipoMusica.PlayOneShot(sonidoMuerte);

        yield return new WaitForSeconds(sonidoMuerte.length);
        SceneManager.LoadScene("NIVEL_UNO");
    }
}
