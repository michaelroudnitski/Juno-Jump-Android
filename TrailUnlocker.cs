using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrailUnlocker : MonoBehaviour {
    List<GameObject> itemPool = new List<GameObject>();
    GameObject currentTrail;
    int currentID = 0;
    public GameObject confetti;
    public GameObject backBtn;
    public GameObject equipBtn;
    public GameObject duplicateNotifier;
    public AudioClip tick_sound;
    public AudioClip final_sound;
    AudioSource audioSource;
    GameObject[] trailPrefabs;

    private void Awake()
    {
        trailPrefabs = Resources.LoadAll("Prefabs/Trails", typeof(GameObject)).Cast<GameObject>().ToArray();
    }

    IEnumerator Start () {
        float delay = 0.07f;
        foreach (GameObject trail in trailPrefabs)
        {
            itemPool.Add(trail);
        }
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        for (int i = 0; i < itemPool.Count * Random.Range(3, 4) + Random.Range(0,itemPool.Count); i++)
        {
            currentID ++;
            if (i % itemPool.Count == 0)
            {
                currentID = 0;
            }
            currentTrail = itemPool[currentID];
            yield return new WaitForSeconds((Mathf.Sqrt(i) * 1) * 0.016f);
            GameObject.Find("Trail Preview").GetComponent<Image>().sprite = currentTrail.GetComponent<Image>().sprite;
            audioSource.PlayOneShot(tick_sound);
        }
        audioSource.PlayOneShot(final_sound);
        if (PlayerPrefs.GetInt("unlocked_" + currentTrail.name) == 1)
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 50);
            Instantiate(duplicateNotifier).transform.SetParent(GameObject.Find("Canvas").transform, false);
            GameObject duplicateNotifInstance = GameObject.Find("New or Duplicate(Clone)");
            duplicateNotifInstance.GetComponentInChildren<Text>().text = "DUPLICATE +100";
        }
        else
        {
            PlayerPrefs.SetInt("unlocked_" + currentTrail.name, 1);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 150);
            Instantiate(duplicateNotifier).transform.SetParent(GameObject.Find("Canvas").transform, false);
            GameObject duplicateNotifInstance = GameObject.Find("New or Duplicate(Clone)");
            duplicateNotifInstance.GetComponentInChildren<Text>().text = "NEW TRAIL";
        }
        Instantiate(confetti, new Vector3(0f, 7.5f, 20f), Quaternion.identity);
        Instantiate(equipBtn).transform.SetParent(GameObject.Find("ButtonsGrid").transform, false);
        GameObject equipBtnInstance = GameObject.Find("EquipBG(Clone)");
        equipBtnInstance.GetComponentInChildren<Text>().text = "EQUIP " + currentTrail.name;
        equipBtnInstance.GetComponent<Button>().onClick.AddListener(EquipTrail);

        Instantiate(backBtn).transform.SetParent(GameObject.Find("ButtonsGrid").transform, false);
        GameObject backBtnInstance = GameObject.Find("BackBG(Clone)");
        backBtnInstance.GetComponent<Button>().onClick.AddListener(Back);

        PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAG");
    }

    public void EquipTrail()
    {
        PlayerPrefs.SetInt("current_trail", currentID);
        SceneManager.LoadScene("Shop");
    }

    public void Back()
    {
        SceneManager.LoadScene("Shop");
    }

}
