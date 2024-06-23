using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemigo2D : MonoBehaviour
{
    [SerializeField] private Transform Pj;

    private bool MirandoR;

    
    // Start is called before the first frame update
    void Start()
    {
        bool isPlayerR = transform.position.x < Pj.transform.position.x;
        Flip(isPlayerR);
        
    }

    private void Flip(bool isPlayerR)
    {
        if ((MirandoR && !isPlayerR) || (!MirandoR && isPlayerR))
        {
            MirandoR = !MirandoR;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
   
}
