using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource BackGround;
    public AudioSource SoundDuko;
    public AudioSource SoundLevel;
    public AudioSource SoundBall;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlaySoundBackGround();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundBackGround()
    {
        BackGround.Play();
    }
    public void PlaySoundDuko()
    {
        SoundDuko.Play();
    }

    public void PlaySoundBall()
    {
        SoundBall.Play();
    }

    public void PlaySoundLevel()
    {
        SoundLevel.Play();
    }


}