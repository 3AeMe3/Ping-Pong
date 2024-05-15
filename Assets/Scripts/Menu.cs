using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Menu : MonoBehaviour
{
    
    [SerializeField] GameObject playerVsNPC;
    
    [SerializeField] GameObject playerVsPlayer;
    
    [SerializeField] GameObject newGame;
    [SerializeField] GameObject continueButtom;
    [SerializeField] Paddle paddleHome;
    [SerializeField] Paddle paddleVisit;

    [SerializeField] Score score;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
       
    }

    public void GoMenu()
    {

        gameObject.SetActive(true);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
       
    }

    public void ModeCpu()
    {
        Time.timeScale = 1;
        score.RestartScore();
        paddleHome.type = Paddle.Type.Player1;
        paddleVisit.type = Paddle.Type.NPC;
        this.gameObject.SetActive(false);
        playerVsNPC.SetActive(false);
        playerVsPlayer.SetActive(false);
    }
    public void ModePlayer()
    {
        Time.timeScale = 1;
        score.RestartScore();
        paddleHome.type = Paddle.Type.Player1;
        paddleVisit.type = Paddle.Type.Player2;
        this.gameObject.SetActive(false);
        playerVsNPC.SetActive(false);
        playerVsPlayer.SetActive(false);
    }
    public void NewGame()
    {
        
        playerVsNPC.SetActive(true);
        playerVsPlayer.SetActive(true);
    }
    public void Continue()
    {
        gameObject.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
