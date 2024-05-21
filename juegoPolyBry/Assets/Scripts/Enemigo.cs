using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida;
    public int vidaAct;
    public Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Wolf_die", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recibirDa�o(int da�o)
    {

        vidaAct -= da�o;
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
