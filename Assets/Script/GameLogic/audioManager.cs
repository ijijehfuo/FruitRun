using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClipName
{
    Jump,
    Slide,
    Explo,
    Coin,
    Food,
}

public class audioManager : MonoBehaviour
{
    public static audioManager Instance;

    public AudioSource MusicSource;
    public AudioSource SfxSource;

    public AudioClip BGM;
    public AudioClip Jump;
    public AudioClip Slide;
    public AudioClip Explo;
    public AudioClip Coin;
    public AudioClip Food;

    private void Awake()
    {
        Instance = this;
        PlayMusic();
    }

    public void PlayMusic()
    {
        MusicSource.clip = BGM;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }

    public void PlaySfx(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);

        audioManager.Instance.PlayEffect(ClipName.Jump);
    }

    public void PlayEffect(ClipName clip)
    {
        switch (clip)
        {
            case ClipName.Jump:
                PlaySfx(Jump);
                break;
            case ClipName.Slide:
                PlaySfx(Slide);
                break;
            case ClipName.Explo:
                PlaySfx(Explo);
                break;
            case ClipName.Coin:
                PlaySfx(Coin);
                break;
            case ClipName.Food:
                PlaySfx(Food);
                break;
            default:
                break;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
