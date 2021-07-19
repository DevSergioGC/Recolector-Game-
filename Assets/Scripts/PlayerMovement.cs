using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento

    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;   
   
    private int contadorMuertes, contadorMonedas = 0;
    public Text tContadorMuertes, tcontadorMonedas, tTextoGanador;
    private Vector2 originalpos;
    public GameObject personaje;

    
    void Start()
    {
        originalpos = new Vector2(personaje.transform.position.x, personaje.transform.position.y);
        tContadorMuertes.text = contadorMuertes.ToString();
        tcontadorMonedas.text = contadorMonedas.ToString();

        rb2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        /*horizontalMove = Input.GetAxisRaw("Horizontal") * velocidad;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }     */   
    }

    
    void FixedUpdate()
    {
        /*controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;*/

        if (Input.GetKey("d") || Input.GetKey("right"))
        {

            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }
    

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moneda"))
        { 
            other.gameObject.SetActive(false);
            contadorMonedas++;            
            tcontadorMonedas.text = contadorMonedas.ToString();
        }

        if (other.gameObject.CompareTag("Enemigos") || other.gameObject.CompareTag("Sierra"))
        {
            contadorMuertes++;
            tContadorMuertes.text = contadorMuertes.ToString();
            personaje.transform.position = new Vector2(-14, 2);
        }

        if (contadorMonedas >= 4)
        {
            tTextoGanador.text = "HAS GANADO!!";
        }
    }    

    void OnCollisionEnter2D (Collision2D micolision)
    {
        if (micolision.gameObject.name == "sierra" || micolision.gameObject.name == "sierra1" || micolision.gameObject.name == "sierra2" 
            || micolision.gameObject.name == "espina")
        {
            contadorMuertes = contadorMuertes + 1;
            tContadorMuertes.text = contadorMuertes.ToString();
            personaje.transform.position = new Vector2(-14, 2);
        }
    }
}
