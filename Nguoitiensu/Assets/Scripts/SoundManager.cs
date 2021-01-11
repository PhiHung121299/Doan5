using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip eat, kill1, kill2, jump,hit,voi;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        eat = Resources.Load<AudioClip>("Eat");
        kill1 = Resources.Load<AudioClip>("kill13");
        kill2 = Resources.Load<AudioClip>("THROWING");
        jump = Resources.Load<AudioClip>("Jump");
        voi = Resources.Load<AudioClip>("voi");
        hit = Resources.Load<AudioClip>("hit");
        audioSource = GetComponent<AudioSource>();

    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "eat":
                audioSource.clip = eat;
                audioSource.PlayOneShot(eat, 1f);
                break;
            case "kill1":
                audioSource.clip = kill1;
                audioSource.PlayOneShot(kill1, 0.6f);
                break;
            case "kill2":
                audioSource.clip = kill2;
                audioSource.PlayOneShot(kill2, 1f);
                break;
            case "jump":
                audioSource.clip = jump;
                audioSource.PlayOneShot(jump, 1f);
                break;
            case "voi":
                audioSource.clip = voi;
                audioSource.PlayOneShot(voi, 1f);
                break;
            case "hit":
                audioSource.clip = hit;
                audioSource.PlayOneShot(hit, 0.5f);
                break;
        }
    }
}
