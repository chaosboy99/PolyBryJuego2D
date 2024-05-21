using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Transform ataque;
    public float radioGolpe;
    public int dañoGolpe;
    private Vida vida;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            Golpe();
        }
       
        
    }
    private void Golpe()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(ataque.position, radioGolpe);

        foreach (Collider2D col in objetos)
        {

            if (col.CompareTag("Enemigo"))
            {   

                col.transform.GetComponent<Enemigo>().recibirDaño(dañoGolpe);
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ataque.position, radioGolpe);
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vida.ReducirVida(1);  
        }
    }*/
}
