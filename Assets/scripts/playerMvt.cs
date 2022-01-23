using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMvt : MonoBehaviour
{
    [SerializeField] float speed,jumpSpeed;
    Rigidbody2D rb;
    float x,y;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        x = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) <= 0.05f)
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); ;
        rb.velocity = new Vector2(x*speed, rb.velocity.y);
    }
}
