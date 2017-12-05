using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadTutorial : MonoBehaviour {

    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject rightPanel2;

    public PlayerController pc;

	void Awake () {
        if (PlayerPrefs.GetInt("tutorialComplete") == 1)
        {
            SceneManager.LoadScene("Main");
        }
    }

    void StartingPrompt()
    {
        leftPanel.SetActive(false);
        rightPanel2.SetActive(false);
        rightPanel.SetActive(true);
    }

    public void RightTapped()
    {
        leftPanel.SetActive(true);
        rightPanel.SetActive(false);
    }

    public void LeftTapped()
    {
        leftPanel.SetActive(false);
        rightPanel2.SetActive(true);
    }

    public void Right2Tapped()
    {
        if (pc.grounded == false)
        {
            rightPanel2.SetActive(false);
        }
    }

    private void Start()
    {
        StartingPrompt();
    }
}
