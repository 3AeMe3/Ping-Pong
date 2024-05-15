using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Score : MonoBehaviour
{
    public enum Type { Home,Visit}
    public Type type;

    [SerializeField] TextMeshProUGUI homeScore;
    [SerializeField] TextMeshProUGUI visitScore;
    [SerializeField] Ball ball;

    int scoreHome =0;
    int scoreVisit =0;

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        homeScore.text = scoreHome.ToString();
        visitScore.text = scoreVisit.ToString();


        float width = Camera.main.orthographicSize * Camera.main.aspect;

        if(type == Type.Home)
        {
            transform.position = new Vector2(-width - 1, 0);
        }
        else
        {
            transform.position = new Vector2(width + 1, 0);

        }
    }

    public void RestartScore()
    {
        ball.Respawn();
        scoreHome = 0;
        scoreVisit = 0;
        homeScore.text = scoreHome.ToString();
        visitScore.text = scoreVisit.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == Type.Home)
        {
            scoreVisit++;
            visitScore.text = scoreVisit.ToString();
            audioSource.PlayOneShot(audioSource.clip);
           
        }
        if(type == Type.Visit)
        {
            scoreHome++;
            homeScore.text = scoreHome.ToString();
            audioSource.PlayOneShot(audioSource.clip);

        }
    }

}
