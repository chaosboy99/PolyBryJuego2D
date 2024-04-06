using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    public static bool EsSuelo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EsSuelo = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EsSuelo = false;
    }
}
