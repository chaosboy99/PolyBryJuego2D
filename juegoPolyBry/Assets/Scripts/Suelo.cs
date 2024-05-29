using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    public static bool EsSuelo;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        EsSuelo = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        EsSuelo = false;
    }
}
