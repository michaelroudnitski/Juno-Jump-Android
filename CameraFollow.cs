using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform player;
    public float offset;
    public float smoothTime = 0.225f;
    private Vector3 velocity = Vector3.zero;

    void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	void Update () {
        Vector3 targetPosition = new Vector3(0, player.position.y + offset, -16);
        if (targetPosition.y > transform.position.y)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
