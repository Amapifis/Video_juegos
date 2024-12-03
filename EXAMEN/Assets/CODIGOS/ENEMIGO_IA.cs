using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class IA : MonoBehaviour
{
    public Transform hero;
    public Transform orcoPos;
    public bool loveo;
    public NavMeshAgent nav;
    public Animator anim;

   
    public VIDAS HeroVida;
    
    void Start()
    {
        loveo = false;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        hero =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        orcoPos = GetComponent<Transform>();
 HeroVida = GameObject.FindGameObjectWithTag("Player").GetComponent<VIDAS>();


    }

    // Update is called once per frame
    void Update()
    {
        orcoMov();
    }

    void orcoMov()
    {
        float distance = Vector3.Distance(hero.position, this.transform.position);

        if (distance < 10)
        {
            loveo = true;
        }
        else
        {
            loveo = false;
        }

        if (loveo)
        {
            nav.destination = hero.position;
            anim.SetBool("RUN_ENEMY", true);
        }
        else
        {
            anim.SetBool("RUN_ENEMY", false);
            anim.SetBool("ATAQUE_ENEMY", false); // Detiene el ataque si no está en rango
            nav.destination = orcoPos.position;
        }

        // Verifica si está en rango para atacar
        if (loveo && distance <= nav.stoppingDistance)
        {
            anim.SetBool("RUN_ENEMY", false); // Detiene la animación de correr
            anim.SetBool("ATAQUE_ENEMY", true); // Inicia la animación de ataque
            if (HeroVida.vidas <= 0)
            {
                anim.SetBool("ATAQUE_ENEMY", false);
                anim.SetBool("VICTORIA", true); // Activa animación de victoria
            }
        }
        else
        {
            anim.SetBool("ATAQUE_ENEMY", false); // Detiene la animación de ataque si sale del rango
        }
    }
}
