using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedRotate;
    private Rigidbody rigidBody;
    private float x, y;
    private Animator animator;

    public float forceJump;
    public bool isJump;
    public int jumpsPerformed = 0;
    public int maxJumps = 2;



    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Convertimos las entradas locales en entradas globales
        Vector3 localMovement = new Vector3(x, 0, y);
        Vector3 globalMovement = transform.TransformDirection(localMovement) * moveSpeed * Time.deltaTime;

        // Aplicamos el movimiento al Rigidbody para que se mueva en el eje X y Z.
        rigidBody.MovePosition(transform.position + globalMovement);

        // Rotamos el objeto.
        transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);

        // Verificamos si el personaje se está moviendo.
        if (x != 0 || y != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Actualizamos las variables de velocidad para la animación.
        animator.SetFloat("Xspeed", x);
        animator.SetFloat("Yspeed", y);

        if (isJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpsPerformed < maxJumps)
                {
                    animator.SetBool("isJumping", true);
                    rigidBody.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
                    jumpsPerformed++;
                    Debug.Log("Salto realizado. Saltos restantes: " + (maxJumps - jumpsPerformed));
                }
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
        else
        {
            jumpsPerformed = 0; // Reiniciar el contador de saltos cuando no esté en contacto con el suelo.
        }


        //verificamos si va atacar
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", true);
            Debug.Log("esta atacando.");
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }


}




