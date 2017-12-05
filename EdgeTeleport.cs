using UnityEngine;

public class EdgeTeleport : MonoBehaviour {

    float horzExtent;

    private void Start()
    {
        horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    void LateUpdate () {
        if (transform.position.x > horzExtent + 0.1f)
        {
            Vector2 position = transform.position;
            position[0] = -horzExtent;
            transform.position = position;
            if (GetComponentInChildren<TrailRenderer>())
            {
                GetComponentInChildren<TrailRenderer>().Clear();
            }
        }
        else if (transform.position.x < -horzExtent - 0.1f)
        {
            Vector2 position = transform.position;
            position[0] = horzExtent;
            transform.position = position;
            if (GetComponentInChildren<TrailRenderer>())
            {
                GetComponentInChildren<TrailRenderer>().Clear();
            }
        }
	}
}
