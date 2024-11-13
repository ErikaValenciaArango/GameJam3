using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    // Cambiar los campos a public
    public AudioSource musicSource;
    public AudioSource effectsSource;
    public AudioMixer master;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Esto mantiene la instancia persistente
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto duplicado
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip music, bool loop)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
        musicSource.loop = loop;
    }
}
