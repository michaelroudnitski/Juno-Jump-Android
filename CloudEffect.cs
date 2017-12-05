using UnityEngine;

public class CloudEffect : MonoBehaviour {

    Transform player;
    PlayerController playerInfo;
    ParticleSystem cloudParticle;

    void Start () {
        player = GameObject.Find("Player").transform;
        playerInfo = player.GetComponent<PlayerController>();
        cloudParticle = GetComponent<ParticleSystem>();
    }
	
	void Update () {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2 && playerInfo.grounded == true)
                {
                    transform.position = player.position;
                    cloudParticle.Emit(15);
                }
            }
        }
    }
}
