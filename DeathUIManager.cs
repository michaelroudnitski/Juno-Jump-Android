using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SceneManagement;

public class DeathUIManager : MonoBehaviour {

    public GameObject confetti;
    public GameObject giftPrompt;
    public GameObject adButton;
    public Image loadingBar;
    public Text score;
    public Text bestScore;
    public Text bestScoreHeader;
    public Text coinText;
    public Text mutedText;
    int highScoreValue;
    int lastScoreValue;
    private float lerp;
    public float duration;
    float current;
    float progress;

    private void Start()
    {
        coinText.text = PlayerPrefs.GetInt("coins").ToString();
        highScoreValue = PlayerPrefs.GetInt("bestScore");
        lastScoreValue = PlayerPrefs.GetInt("currentScore");
        if (PlayerPrefs.GetInt("deaths") == 3 && PlayerPrefs.GetInt("giftAccepted") == 0)
        {
            giftPrompt.SetActive(true);
        }
        if (lastScoreValue / highScoreValue >= 1)
        {
            bestScoreHeader.text = "NEW BEST";
            PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_score_leaderboards, PlayerPrefs.GetInt("bestScore"));
            loadingBar.GetComponent<Image>().color = new Color(0f, 0.78f, 0.32f);
            score.color = new Color(0f, 0.78f, 0.32f);
            Instantiate(confetti, new Vector3(0f, 1.35f, 0f), Quaternion.identity);
        }
        score.text = lastScoreValue.ToString();
        bestScore.text = highScoreValue.ToString();
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            mutedText.text = "SFX\nOFF";
        }
        if (PlayerPrefs.GetInt("deaths") % 3 == 0)
        {
            adButton.SetActive(true);
        }
    }

    public void Update()
    {
        lerp += Time.deltaTime * duration;
        current = (int)Mathf.Lerp(0, lastScoreValue, lerp);
        float progress = current / highScoreValue;
        score.text = current.ToString();
        loadingBar.fillAmount = progress;
    }

    public void LoadMain()
    {
        PlayerPrefs.SetInt("tutorialComplete", 1);
        CloseGiftPrompt();
        PlayerPrefs.SetInt("giftAccepted", 0);
        SceneManager.LoadScene("Main");
    }

    public void LoadShop()
    {
        CloseGiftPrompt();
        SceneManager.LoadScene("Shop");
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CggI5crG7DEQAhAA");
        }
    }

    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Social.ShowAchievementsUI();
        }
    }

    public void CloseGiftPrompt()
    {
        if (giftPrompt.activeSelf == true)
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 150);
            coinText.text = PlayerPrefs.GetInt("coins").ToString();
            giftPrompt.SetActive(false);
            PlayerPrefs.SetInt("giftAccepted", 1);
            coinText.GetComponent<Animator>().SetTrigger("Trigger");
            GameObject.Find("Coin Icon").GetComponent<Animator>().SetTrigger("Trigger");
        }

    }

    public void Mute()
    {
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            PlayerPrefs.SetInt("mute", 1);
            mutedText.text = "SFX\nOFF";
        }
        else
        {
            PlayerPrefs.SetInt("mute", 0);
            mutedText.text = "SFX\nON";
        }
    }
}
