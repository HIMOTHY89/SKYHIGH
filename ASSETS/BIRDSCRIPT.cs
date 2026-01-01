using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class BIRDSCRIPT : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Text highscore;
void Start()
{
    logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    highscore.text = "HIGHSCORE:" + PlayerPrefs.GetInt("Highscore").ToString();

   
    ADSManager.Instance.bannerAds?.showBannerAd();
}


    void Update()
    {
    
    if (birdIsAlive)
    {
    if (Touchscreen.current != null && 
        Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
    {
        myRigidbody.linearVelocity = Vector2.up * flapStrength;
    }

    if (Mouse.current != null &&
        Mouse.current.leftButton.wasPressedThisFrame)
    {
        myRigidbody.linearVelocity = Vector2.up * flapStrength;
    }

    }



        if (transform.position.y > 18 || transform.position.y < -18)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

     ADSManager.Instance.bannerAds.showBannerAd();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
      
        birdIsAlive = false;

    }
}
