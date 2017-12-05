using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    float vertExtent;
    public AudioClip sound;
    AudioSource audioSource;

    void Start () {
        vertExtent = Camera.main.orthographicSize;
        PlayerPrefs.SetInt("currentScore", 0);
        GameObject.Find("Score").GetComponent<Text>().text = PlayerPrefs.GetInt("currentScore").ToString();
        GameObject.Find("Best Score").GetComponent<Text>().text = PlayerPrefs.GetInt("bestScore", 0).ToString();
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }
	
	void Update () {
		if (Camera.main.transform.position.y - vertExtent > transform.position.y)
        {
            PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths") + 1);
            audioSource.PlayOneShot(sound);
            SceneManager.LoadScene("Death");
        }
	}
}
