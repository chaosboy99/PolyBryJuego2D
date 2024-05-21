using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Animalmovement : MonoBehaviour
{
    public float speed = 8f;
    public float distancetoPlayer = 10f;
    public bool attaking = false, moveToLeft, moveToRight, wait, dead = false;
    int movimiento;
    public Rigidbody2D rb2D;
    public SpriteRenderer Sprite;
    public Animator Animator;
    public Enemigo enemigo;
    public int enemyHp;
    
    /*public SpriteRenderer Sprite;
    public Animator Animator;*/

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        accion();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHp = enemigo.GetActualLife();
        if (enemyHp <= 0)
        {
            wait = true;
            moveToLeft = false;
            moveToRight = false;
            Animator.SetBool("Wolf_idle", true);
            Animator.SetBool("Wolf_walk", false);
        }

        if (wait)
        {
            rb2D.velocity = new Vector2(0, 0);
        }

        if (moveToLeft)
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            Sprite.flipX = true;            
        }
        else if (moveToRight)
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            Sprite.flipX = false;
        }

        if (attaking)
        {
            wait = false;
            moveToLeft = false;
            moveToRight = false;
        }
        
    }

    void accion()
    {
        movimiento = Random.Range(1, 4);

        if (movimiento == 1)
        {
            wait = true;
            moveToLeft = false;
            moveToRight = false;
            Animator.SetBool("Wolf_idle", true);
            Animator.SetBool("Wolf_walk", false);
            Invoke("accion", Random.Range(1, 3));
        }
        else if (movimiento == 2)
        {
            wait = false;
            moveToLeft = true;
            moveToRight = false;
            Animator.SetBool("Wolf_idle", false);
            Animator.SetBool("Wolf_walk", true);
            Invoke("accion", Random.Range(1, 3));
        }
        else if (movimiento == 3)
        {
            wait = false;
            moveToLeft = false;
            moveToRight = true;
            Animator.SetBool("Wolf_idle", false);
            Animator.SetBool("Wolf_walk", true);
            Invoke("accion", Random.Range(1, 3));
        }
    }
    

}
