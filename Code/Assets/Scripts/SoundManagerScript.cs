using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a script that control all the sound effect in the game
/// </summary>
public class SoundManagerScript : MonoBehaviour
{
    /// <summary>
    /// Declare all variable and it's data type
    /// </summary>
    public static AudioClip bulletSound, gameOverSound, crashSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        bulletSound = Resources.Load<AudioClip>("laser");
        crashSound = Resources.Load<AudioClip>("crash");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            // Plays a sound effect if the player shoot
            case "laser":
                audioSrc.PlayOneShot(bulletSound);
                break;
            // Plays a sound effect when the player collide with an obstacle
            case "crash":
                audioSrc.PlayOneShot(crashSound);
                break;
        }
    }
}
