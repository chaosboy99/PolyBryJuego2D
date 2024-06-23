using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemigo2D : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Transform Pj;
    [SerializeField] public Animator Ani;

    private bool MirandoR;
    private int hitCount = 0;
    private const int maxHits = 3;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Pj.position, Speed * Time.deltaTime);
        Ani.SetBool("Run", true);
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
    public void ReceiveHit()
    {
        hitCount++;
        if (hitCount >= maxHits)
        {
            Destroy(gameObject);
        }
    }


}
