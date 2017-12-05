using UnityEngine;

public class Planets : MonoBehaviour {

    public float speed;

    float tempCamPos;

    private void Start()
    {
        tempCamPos = Camera.main.transform.position.y;
    }

    void Update () {
        if (Camera.main.transform.position.y != tempCamPos)
        {
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y - speed, 10);
            tempCamPos = Camera.main.transform.position.y;
        }        
    }
}
