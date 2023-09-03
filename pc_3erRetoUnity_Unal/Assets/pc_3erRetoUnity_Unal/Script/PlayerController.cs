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



    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Calculamos el vector de movimiento en función de las entradas.
        Vector3 movement = new Vector3(x * moveSpeed * Time.deltaTime, 0, y * moveSpeed * Time.deltaTime);

        // Aplicamos el movimiento al Rigidbody para que se mueva en el eje X y Z.
        rigidBody.MovePosition(transform.position + movement);

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
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("isJumping", true);
                rigidBody.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
                Debug.Log("Esta saltando.");
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
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




