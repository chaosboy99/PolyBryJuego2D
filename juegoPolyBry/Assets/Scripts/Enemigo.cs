using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida;
    int vidaAct;


    // Start is called before the first frame update
    void Start()
    {
        vidaAct = vida;
        
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
        Destroy(gameObject);
    }
}
