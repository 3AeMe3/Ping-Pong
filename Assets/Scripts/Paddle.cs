using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public enum Type { Player1,Player2,NPC};
    public Type type;

     float speed =5;
    Rigidbody2D rb;

    [HideInInspector]
    public int direction = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        float width = Camera.main.orthographicSize * Camera.main.aspect;

        if(transform.position.x < 0)
        {
            transform.position = new Vector2(-width + 1,0);
        }
        else
        {
            transform.position = new Vector2(width - 1 ,0); 
        }
    }
    private void Update()
    {
        if(type == Type.Player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = 1;
            }else if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = -1;
            }
            else
            {
                direction = 0;
            }
        }else if(type == Type.Player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                direction = 1;
            }else if (Input.GetKey(KeyCode.S))
            {
                direction = -1;
            }else
            {
                direction = 0;
            }
        }


            rb.velocity = Vector2.up * direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }



}
