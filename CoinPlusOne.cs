using UnityEngine;

public class CoinPlusOne : MonoBehaviour {

    void OnBecameVisible()
    {
        Invoke("MoveOffScreen", 0.5f);
    }

    void MoveOffScreen()
    {
        gameObject.transform.position = new Vector2(-15f, transform.position.y);
    }
}
