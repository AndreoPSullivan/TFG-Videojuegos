using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager


{
    public static void PlaySound(AudioClip clip) {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audiosource = soundGameObject.AddComponent<AudioSource>();

        audiosource.PlayOneShot(clip);
    }
}
