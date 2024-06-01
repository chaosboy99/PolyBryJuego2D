using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Transform ataque;
    public float radioGolpe;
    public int dañoGolpe;
    private Vida vida;
    public Mov mov;
    public float cooldownAttackTime = 0.8f, lastAttackTime = -1000f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("e") && Time.time >= lastAttackTime + cooldownAttackTime && (!Input.GetKey("a") || !Input.GetKey("d")))
        {
            lastAttackTime = Time.time;

            if (mov.Sprite.flipX == false)
            {
                GolpeIzq();
            }
            else if (mov.Sprite.flipX == true)
            {
                GolpeDer();
            }
        }


    }
    private void GolpeIzq()
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
    private void GolpeDer()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(new Vector2(transform.position.x - (ataque.position.x - transform.position.x), ataque.position.y), radioGolpe);

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
}
