using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Animalmovement : MonoBehaviour
{
    public float speed = 6f, checkDistanceToPlayer = 10f;
    private bool attacking = false, moveToLeft, moveToRight, wait, hunt;
    public bool dead = false;
    private int movimiento;
    public int enemyHp = 20;
    public Rigidbody2D rb2D;
    public SpriteRenderer Sprite;
    public Animator Animator;
    public Enemigo enemigo;
    public Transform playerPos;
    public Vida vida;
    public Vector2 distanceAnimalToPlayer;
    private float actionCooldown = 0f;
    private float actionCooldownTime = 2f; // Tiempo de espera entre acciones

    // Start is called before the first frame update
    void Start()
    {
        print("START");
        rb2D = GetComponent<Rigidbody2D>();
        accion();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyHp = enemigo.GetActualLife();
        distanceAnimalToPlayer = new Vector2(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y);

        if (enemyHp <= 0)
        {
            wait = true;
            moveToLeft = false;
            moveToRight = false;
            Animator.SetBool("Wolf_idle", true);
            Animator.SetBool("Wolf_walk", false);
            Animator.SetBool("Wolf_run", false);
        }

        if (actionCooldown <= 0f && Mathf.Abs(distanceAnimalToPlayer.x) < checkDistanceToPlayer)
        {
            accion();
            actionCooldown = actionCooldownTime; // Reiniciar el tiempo de espera
        }

        actionCooldown -= Time.fixedDeltaTime;
        if (attacking)
        {
            // Añadir la lógica de ataque aquí
            Animator.SetBool("Wolf_attack", true);
            Animator.SetBool("Wolf_idle", false);
            Animator.SetBool("Wolf_walk", false);
            Animator.SetBool("Wolf_run", false);
            
            // Aquí puedes implementar la lógica del daño al jugador
            // Por ejemplo: enemigo.AttackPlayer();

            rb2D.velocity = Vector2.zero; // Mantener al lobo quieto mientras ataca
        }
        if (hunt)
        {
            if (Mathf.Abs(distanceAnimalToPlayer.x) < checkDistanceToPlayer)
            {
                // Perseguir al jugador
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.position.x, transform.position.y), speed * 1.4f * Time.deltaTime);
                Animator.SetBool("Wolf_idle", false);
                Animator.SetBool("Wolf_walk", false);
                Animator.SetBool("Wolf_run", true);
                Animator.SetBool("Wolf_attack", false);
                Sprite.flipX = distanceAnimalToPlayer.x > 0;
            }
        }
        else if (wait)
        {
            rb2D.velocity = Vector2.zero;
            if (Mathf.Abs(distanceAnimalToPlayer.x) > checkDistanceToPlayer && Mathf.Abs(distanceAnimalToPlayer.x) < 12)
            {
                Sprite.flipX = distanceAnimalToPlayer.x > 0;
            }
        }
        else if (moveToLeft)
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            Sprite.flipX = true;
        }
        else if (moveToRight)
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            Sprite.flipX = false;
        }

        if (attacking)
        {
            wait = false;
            moveToLeft = false;
            moveToRight = false;
        }
    }

    void accion()
    {
        print("------------------------Nueva accion------------------------");


        if (Mathf.Abs(distanceAnimalToPlayer.x) > 12)
        {
            movimiento = Random.Range(1, 4); // Movimiento aleatorio
        }
        else if (Mathf.Abs(distanceAnimalToPlayer.x) > checkDistanceToPlayer && Mathf.Abs(distanceAnimalToPlayer.x) <= 12)
        {
            movimiento = 1; // Quedarse quieto en la dirección adecuada
        }
        else if (Mathf.Abs(distanceAnimalToPlayer.x) <= checkDistanceToPlayer && Mathf.Abs(distanceAnimalToPlayer.x) > 1.5f)
        {
            movimiento = 4; // Perseguir al jugador
        }
        else if (hunt && Mathf.Abs(distanceAnimalToPlayer.x) <= 1.5f)
        {
            movimiento = 5; // Ataque
        }

        print("ACCION ---------------------> " + movimiento);
        switch (movimiento)
        {
            case 1:
                wait = true;
                moveToLeft = false;
                moveToRight = false;
                hunt = false;
                Animator.SetBool("Wolf_idle", true);
                Animator.SetBool("Wolf_walk", false);
                Animator.SetBool("Wolf_run", false);
                Animator.SetBool("Wolf_attack", false);
                break;
            case 2:
                wait = false;
                moveToLeft = true;
                moveToRight = false;
                hunt = false;
                Animator.SetBool("Wolf_idle", false);
                Animator.SetBool("Wolf_walk", true);
                Animator.SetBool("Wolf_run", false);
                Animator.SetBool("Wolf_attack", false);
                break;
            case 3:
                wait = false;
                moveToLeft = false;
                moveToRight = true;
                hunt = false;
                Animator.SetBool("Wolf_idle", false);
                Animator.SetBool("Wolf_walk", true);
                Animator.SetBool("Wolf_run", false);
                Animator.SetBool("Wolf_attack", false);
                break;
            case 4:
                wait = false;
                moveToLeft = false;
                moveToRight = false;
                hunt = true;
                break;
            case 5:
                wait = false;
                moveToLeft = false;
                moveToRight = false;
                hunt = false;
                attacking = true;
                break;
        }
        print("IDLE: " + Animator.GetBool("Wolf_idle"));
        print("WALK: " + Animator.GetBool("Wolf_walk"));
        print("RUN: " + Animator.GetBool("Wolf_run"));
        print("ATTACKING: " + Animator.GetBool("Wolf_attack"));
        Invoke("accion", Random.Range(1, 3.5f));
    }
}
