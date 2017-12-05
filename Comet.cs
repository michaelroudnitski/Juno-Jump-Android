using UnityEngine;

public class Comet : MonoBehaviour
{
    float xVel;
    float yVel;
    Rigidbody2D rb;
    float vertExtent;
    float horzExtent;
    int direction; // 0 = spawn at left and move right, 1 = opposite
    public AudioClip sound;
    AudioSource audioSource;

    public void ActivateComet()
    {
        gameObject.SetActive(true);
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        rb = transform.gameObject.GetComponent<Rigidbody2D>();
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        gameObject.GetComponent<TrailRenderer>().Clear();
        direction = Random.Range(0, 2);
        yVel = Random.Range(2f, 4f);
        xVel = Random.Range(8f, 10f);
        if (direction == 0)
        {
            transform.position = new Vector3(-horzExtent + 0.06f, Camera.main.transform.position.y + vertExtent - 2f, 5);
            rb.velocity = new Vector2(xVel, yVel);
        }
        else
        {
            transform.position = new Vector3(horzExtent - 0.06f, Camera.main.transform.position.y + vertExtent - 2f, 5);
            rb.velocity = new Vector2(-xVel, yVel);
        }
        audioSource.PlayOneShot(sound);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
