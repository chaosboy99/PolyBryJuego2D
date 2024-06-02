using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform enemyAttack;
    public float radioGolpe;
    public int dañoGolpe;
    private Vida vida;
    public Animalmovement animalmovement;
    public float cooldownAttackTime = 0.8f, lastAttackTime = -1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (animalmovement.attacking && Time.time >= lastAttackTime + cooldownAttackTime)
        {
            lastAttackTime = Time.time;

            if (animalmovement.Sprite.flipX == false)
            {
                GolpeIzq();
            }
            else if (animalmovement.Sprite.flipX == true)
            {
                GolpeDer();
            }
        }


    }
    private void GolpeIzq()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(enemyAttack.position, radioGolpe);

        foreach (Collider2D col in objetos)
        {

            if (col.CompareTag("Player"))
            {

                col.transform.GetComponent<Vida>().recibirDaño(dañoGolpe);

            }

        }
    }
    private void GolpeDer()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(new Vector2(transform.position.x - (enemyAttack.position.x - transform.position.x), enemyAttack.position.y), radioGolpe);

        foreach (Collider2D col in objetos)
        {
            if (col.CompareTag("Player"))
            {
                col.transform.GetComponent<Vida>().recibirDaño(dañoGolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyAttack.position, radioGolpe);
    }
}
