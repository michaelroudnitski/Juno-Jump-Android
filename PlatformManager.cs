using UnityEngine;

public class PlatformManager : MonoBehaviour {

    GameObject[] platforms;
    Rigidbody2D playerRB;
    PlayerController playerInfo;
    public Color origColor;
    int amtOfPlats;
    float vertExtent;
    float horzExtent;
    
    public float height = 0;
    public float platformVerticalDistance;

	void Start () {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        amtOfPlats = platforms.Length;

        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;

        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerInfo = playerRB.GetComponent<PlayerController>();

        //for (int i = 0; i < amtOfPlats; i++)
        //{
        //    RepositionPlatform(i);
        //}

        //platforms[0].transform.position = new Vector2(1, platforms[0].transform.position.y);
        //platforms[1].transform.position = new Vector2(0.8f, platforms[1].transform.position.y);
    }

	void Update () {
        if (playerInfo.grounded == true)
        {
            for (int i = 0; i < amtOfPlats; i++)
            {
                if (platforms[i].transform.position.y < Camera.main.transform.position.y - vertExtent)
                {
                    RepositionPlatform(i);
                }
            }
        }
	}

    void RepositionPlatform (int i)
    {
        platforms[i].transform.position = new Vector2(Random.Range(-horzExtent + 1.5f, horzExtent - 1.5f), height);
        platforms[i].GetComponent<SpriteRenderer>().color = origColor;
        platforms[i].GetComponent<PlatformStatus>().landed = false;
        height += platformVerticalDistance;
    }
}
