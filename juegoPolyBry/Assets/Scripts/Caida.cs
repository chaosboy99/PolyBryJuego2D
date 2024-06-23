using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Vida vidaSc = FindObjectOfType<Vida>();
        if (Suelo.EsSuelo == false && vidaSc.CantidadCorazones != 0)
        {
           
            vidaSc.PerderCorazones();
            FindObjectOfType<Mov>().SendMessage("Spawn");
            
        }
        else if (vidaSc.CantidadCorazones == 0)
        {
            vidaSc.Die();
        }
    }
}
