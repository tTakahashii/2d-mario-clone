using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    private static AudioSource staticSource;
    private void Awake()
    {
        staticSource = musicSource;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (musicSource.isPlaying)
            {
                MusicManager.StopMusic();
            }
            else
            {
                MusicManager.StartMusic();
            }
        }
    }

    public static class MusicManager
    {
        public static void StartMusic()
        {
            staticSource.Play();
        }

        public static void StopMusic()
        {
            staticSource.Stop();
        }

        public static void ChangeMusic(AudioClip newMusic)
        {
            staticSource.clip = newMusic;
        }

        public static void SetLooping(bool shouldLoop)
        {
            staticSource.loop = shouldLoop;
        }
    }
}
