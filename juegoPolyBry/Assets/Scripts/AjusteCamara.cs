using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjusteCamara : MonoBehaviour
{
    public Transform pj;
    private Vector3 offset;
    public BoxCollider2D limite;
    private bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        isFollowing = false;
        offset = transform.position - pj.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing) 
        {
            transform.position = pj.position + offset; 
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == pj) 
        {
            Debug.Log("El personaje ha entrado en el límite.");
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == pj)
        {
            Debug.Log("El personaje ha salido del límite.");
            isFollowing = false;
        }
    }
}
