using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public bool grounded = false;
    public float jumpForce;
    public float xVel;

    ParticleSystem particles;
    bool usingParticles = false;

    public AudioClip sound;
    AudioSource audioSource;
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        if (particles)
        {
            particles.Stop();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
        if (particles)
        {
            particles.Play();
        }
    }

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    void Update () {
        //if (Input.GetMouseButtonDown(0) && grounded == true)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //    audioSource.PlayOneShot(sound);
        //    anim.SetTrigger("Jumped");
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (rb.velocity.x > 0)
        //    {
        //        rb.velocity = new Vector2(-xVel, rb.velocity.y);
        //    }
        //    else
        //    {
        //        rb.velocity = new Vector2(xVel, rb.velocity.y);
        //    }
        //    if (grounded == true)
        //    {
        //        GetComponentInChildren<TrailRenderer>().Clear();
        //    }
        //}

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2 && grounded == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    audioSource.PlayOneShot(sound);
                    anim.SetTrigger("Jumped");
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    if (rb.velocity.x > 0)
                    {
                        rb.velocity = new Vector2(-xVel, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(xVel, rb.velocity.y);
                    }
                    if (grounded == true)
                    {
                        GetComponentInChildren<TrailRenderer>().Clear();
                    }
                }
            }
        }
    }
}
