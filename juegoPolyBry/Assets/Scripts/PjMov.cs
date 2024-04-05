using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMov : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float MovHorizontal = Input.GetAxis("Horizontal");
        float MovVertical = Input.GetAxis("Vertical");
        Vector2 mov = new Vector2(MovHorizontal, MovVertical);

        rb.velocity = mov * speed;
    }
}
