using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    TrailRenderer trailRenderer;
    [SerializeField] GameObject goalExplosion;
    [SerializeField] GoalAnim goalAnim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        trailRenderer.enabled = false;
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke(nameof(Trown), 0.5f);

    }
    void Trown()
    {
        trailRenderer.enabled = true;

        int randomX = Random.Range(0, 2);
        if (randomX == 0)
        {
            randomX = -1;
        }
        int randomY = Random.Range(0,2);
        if(randomY == 0)
        {
            randomY = -1;
        }
        Vector2 randomPos = new Vector2(randomX, randomY);
        rb.velocity = randomPos * speed;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Instantiate(goalExplosion, transform.position, Quaternion.identity);
            goalAnim.ShowAnimation();
            Debug.Log("se llamo a la animacion" );
            Respawn();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audio.clip);
    }
}
