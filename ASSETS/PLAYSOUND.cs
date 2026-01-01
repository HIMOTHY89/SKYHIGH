using UnityEngine;
using System;

public class PLAYSOUND : MonoBehaviour
{
  public void PLAY()
    {
        SoundManager.Instance.PlaySound2D("BUTTONCLICK");
    }
    

   
    
}
