using System.Linq;
using UnityEngine;

public class TrailSpawner : MonoBehaviour {

    GameObject currentTrail;

    private void Awake()
    {
        currentTrail = Instantiate(Resources.LoadAll("Prefabs/Trails", typeof(GameObject)).Cast<GameObject>().ToArray()[PlayerPrefs.GetInt("current_trail", 14)]);
    }

    void Start () {
        currentTrail.transform.SetParent(GameObject.Find("Player").transform, false);
        currentTrail.transform.localPosition = new Vector3(0f, 0f, 20f);
    }
}
