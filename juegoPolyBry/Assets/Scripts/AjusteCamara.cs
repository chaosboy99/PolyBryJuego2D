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
            transform.position = new Vector3(pj.position.x + offset.x, transform.position.y, pj.position.z + offset.z);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == pj) 
        {
            isFollowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == pj)
        {
            isFollowing = false;
        }
    }
}
