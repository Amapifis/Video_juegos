using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HEROMOVE : MonoBehaviour
{
    public float velPersonaje;
    public Transform playerCamera;
    public float rotacionVelocidad;
    public float tiempoRotacion;
    public Rigidbody rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heroMove();
    }
    void heroMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dirreccion = new Vector3(h, 0, v);

        if (dirreccion.magnitude >= 0.1f) 
        {
            float target = Mathf.Atan2(dirreccion.x, dirreccion.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref rotacionVelocidad, tiempoRotacion);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movimientoDireccion = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            rb.MovePosition(rb.position + movimientoDireccion.normalized *velPersonaje * Time.deltaTime);

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
    
}
