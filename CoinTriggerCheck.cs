using UnityEngine;
using UnityEngine.UI;

public class CoinTriggerCheck : MonoBehaviour {

    public GameObject coinManager;
    CoinManager coinManagerScript;
    public Transform coinPickupText;

    public Animator coinIconAnim;
    public Animator coinTextAnim;
    public AudioClip sound;
    AudioSource audioSource;
    public Text coinText;

	void Start () {
        coinManagerScript = coinManager.GetComponent<CoinManager>();
        coinText.text = PlayerPrefs.GetInt("coins").ToString();
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Coin")
        {
            coinPickupText.position = collision.transform.position;
            collision.transform.position = new Vector2(Random.Range(-2.25f, 2.25f), coinManagerScript.height);
            coinManagerScript.height += coinManagerScript.coinVerticalDistance;
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
            coinIconAnim.SetTrigger("Trigger");
            coinTextAnim.SetTrigger("Trigger");
            audioSource.PlayOneShot(sound);
            coinText.text = PlayerPrefs.GetInt("coins").ToString();
        }
    }
}
