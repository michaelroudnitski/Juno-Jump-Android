using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }
}
