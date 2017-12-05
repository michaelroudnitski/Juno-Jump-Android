using UnityEngine;

public class CoinManager : MonoBehaviour {

    GameObject[] coins;
    Rigidbody2D playerRB;
    PlayerController playerInfo;
    int amtOfCoins;
    float vertExtent;

    public float height;
    public float coinVerticalDistance;

    void Start () {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        amtOfCoins = coins.Length;

        vertExtent = Camera.main.orthographicSize;

        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerInfo = playerRB.GetComponent<PlayerController>();

        for (int i = 0; i < amtOfCoins; i++)
        {
            RepositionCoin(i);
        }
    }

	void Update () {
        if (playerInfo.grounded == true)
        {
            for (int i = 0; i < amtOfCoins; i++)
            {
                if (coins[i].transform.position.y < Camera.main.transform.position.y - vertExtent)
                {
                    RepositionCoin(i);
                }
            }
        }
	}

    void RepositionCoin (int i)
    {
        coins[i].transform.position = new Vector2(Random.Range(-2.25f, 2.25f), height);
        height += coinVerticalDistance;
    }
}
