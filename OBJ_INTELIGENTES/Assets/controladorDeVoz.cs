using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class controladorDeVoz : MonoBehaviour
{
    // Variables públicas para controlar el movimiento y la posición de destino
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float moveSpeed = 1f; // Velocidad de movimiento

    // Variables privadas
    private bool isMoving = false;

    KeywordRecognizer keywordRecognizer; // Sistema de reconocimiento de voz de Windows
    Dictionary<string, Action> wordToAction; // Diccionario de palabras

    void Start()
    {
        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("azul", Azul);
        wordToAction.Add("rojo", Rojo);
        wordToAction.Add("verde", Verde);
        wordToAction.Add("arriba", Arriba);
        wordToAction.Add("elpico", elpico);
        wordToAction.Add("vuelve", vuelve);
        wordToAction.Add("abracadabra", abracadabra);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;
        keywordRecognizer.Start();
    }

    private void abracadabra()
    {
        transform.localScale -= new Vector3(0.7f, 0.7f, 0.1f);
        GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
    }

    private void vuelve()
    {
        endPosition = startPosition; // Define la posición de destino como la posición inicial
        isMoving = true; // Activa el movimiento de regreso
    }

    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    private void elpico()
    {
        transform.localScale -= new Vector3(0.7f, 0.7f, 0.1f);
        startPosition = transform.position; // Posición actual
        endPosition = new Vector3(5, 5, 5); // Cambia esta posición según donde quieres que se mueva el objeto
        isMoving = true; // Activa el movimiento
    }

    private void Arriba()
    {
        transform.Translate(0, 1, 0);
    }

    private void Verde()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void Rojo()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    private void Azul()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, moveSpeed * Time.deltaTime);

            // Detener el movimiento cuando esté cerca del destino
            if (Vector3.Distance(transform.position, endPosition) < 0.01f)
            {
                transform.position = endPosition;
                isMoving = false;
            }
        }
    }
}
