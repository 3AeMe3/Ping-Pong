using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallDetected : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] Ball ball;
  
    Vector2 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
  

    private void Update()
    {
        transform.position = startPosition;


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball")) 
        {
            if(paddle.type == Paddle.Type.NPC)
            {
                
                if (paddle.transform.position.y > ball.transform.position.y)
                {
                    paddle.direction = -1;
                }
                else
                {
                    paddle.direction = 1;

                }
            }
        }
    }
}
