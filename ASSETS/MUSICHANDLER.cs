using System;
using UnityEngine;

public class MUSICHANDLER : MonoBehaviour
{
    public AudioClip[] MUSICTRACKS = new AudioClip[11];
    public AudioSource audioSource;
    public bool isGameOver = false; // <-- clearer name than "isplaying"

    public System.Random random = new System.Random();

    void Start()
    {
        audioSource.volume = 0;
        int tracks = random.Next(0, MUSICTRACKS.Length); // random track
        audioSource.clip = MUSICTRACKS[tracks];
        audioSource.Play();
    }

    void Update()
    {
        // --- 🔴 Game over: fade out ---
        if (isGameOver)
        {
            if (audioSource.volume > 0)
            {
                audioSource.volume -= Time.deltaTime; // fade out
            }
            else
            {
                audioSource.Stop(); // stop completely
            }
            return; // skip normal behaviour
        }

        // --- 🎵 Normal music loop when not game over ---
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 0; // reset volume
            int tracks = random.Next(0, MUSICTRACKS.Length);
            audioSource.clip = MUSICTRACKS[tracks];
            audioSource.Play();
        }
        else if (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime; // fade in smoothly
        }
    }
}
