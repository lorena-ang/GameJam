using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip damage, recover, lost;
    public AudioSource audioSrc;

    public void playDamage()
    {
        audioSrc.PlayOneShot(damage);
    }
    public void playRecover()
    {
        audioSrc.PlayOneShot(recover);
    }
    public void playLost()
    {
        audioSrc.PlayOneShot(lost);
    }
}