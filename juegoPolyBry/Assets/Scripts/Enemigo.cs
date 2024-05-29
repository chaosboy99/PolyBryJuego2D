using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida;
    private int vidaAct;
    public Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Wolf_die", false);
        vidaAct = vida; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recibirDaño(int daño)
    {

        vidaAct -= daño;
        if (vidaAct <= 0)
        {
            die();
        }
        
    }
    void die()
    {
        animator.SetBool("Wolf_die", true);
        
        Invoke("Destroy", (float)1.3);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }

    public int GetActualLife()
    {
        return vidaAct;
    }

}
