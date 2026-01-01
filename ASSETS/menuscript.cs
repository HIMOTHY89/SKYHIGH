using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class menuscript : MonoBehaviour
{
    public Slider VolumeSound;
    public Slider Volumemusic;

    public AudioMixer AudioMixer;
    public void ChangeScene( )
    {
        SceneManager.LoadScene("SampleScene");
          LoadVolume();
         
    }
        
    
    public void Quit()
    {
        Application.Quit();
    }

     public void UpdateMusicVolume(float volume)
    {
        AudioMixer.SetFloat("MusicVolume", volume);
    }
 
    public void UpdateSoundVolume(float volume)
    {
        AudioMixer.SetFloat("SFXVolume", volume);
    }

       public void SaveVolume()
    {
        AudioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
 
        AudioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
      public void LoadVolume()
    {
        Volumemusic.value = PlayerPrefs.GetFloat("MusicVolume");
        VolumeSound.value = PlayerPrefs.GetFloat("SFXVolume");
    }

}
