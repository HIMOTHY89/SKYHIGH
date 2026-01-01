using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Advertisements;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
   
    public int playerScore;
    public Text scoreText;
    public DIFFICULTYMANAGER DIFFICULTYManager;
    private bool hasShownAd = false;

   
   
    public int highscore;
    public Text Highscore;

    public GameObject GameOverScreen;

   
    

    // 👇 This is what makes the slot appear in the Inspector
    public MUSICHANDLER musicHandler;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

  public void RestartGame()
{
    Time.timeScale = 1f; // MUST reset before loading
    musicHandler.isGameOver = false;
    hasShownAd = false;

   
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

   
   
    

   
   public void gameOver()
{
    
    

    GameOverScreen.SetActive(true);
    if (playerScore > PlayerPrefs.GetInt("Highscore", 0))
    {
        highscore = playerScore;
        PlayerPrefs.SetInt("Highscore", playerScore);
        Highscore.text = "HIGHSCORE:" + highscore.ToString();
    }

    
    if (!hasShownAd)
    {
        ADSManager.Instance.intersitialAds.ShowIntersitialAds();
        hasShownAd = true;
    }

    musicHandler.isGameOver = true;
    ADSManager.Instance.bannerAds.HideBanner();
}

    public void TRACKSCORE()
    {
        if (playerScore > 10 && playerScore == 20)
        {
            DIFFICULTYManager.DIFFICULTY();
        }
        if (playerScore > 20 && playerScore == 50)
        {
            DIFFICULTYManager.DIFFICULTY1();
        }

        if (playerScore > 50 && playerScore == 1000)
        {
            DIFFICULTYManager.DIFFICULTY2();
        } 
        
    }
       public static LogicScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        StartCoroutine(DisplayBannerWithDelay());
        
    }
    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
      
        ADSManager.Instance.bannerAds.showBannerAd();

    }
   

   
}
