using UnityEngine;
using UnityEngine.UI;

public class PlatformStatus : MonoBehaviour {

    public bool landed = false;
    public Color landedColor;
    Text score;
    Text best;
    public Comet comet;
    Animator platformAnim;
    public Animator scoreAnim;
    public DifficultyModifier difficulty;
    public AudioClip sound;
    AudioSource audioSource;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        best = GameObject.Find("Best Score").GetComponentInChildren<Text>();
        platformAnim = gameObject.GetComponent<Animator>();
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int currentScoreVal = PlayerPrefs.GetInt("currentScore");
        int bestScoreVal = PlayerPrefs.GetInt("bestScore");
        if (landed == false)
        {
            landed = true;
            PlayerPrefs.SetInt("currentScore", currentScoreVal + 1);
            currentScoreVal = PlayerPrefs.GetInt("currentScore");
            score.text = currentScoreVal.ToString();
            if (currentScoreVal > bestScoreVal)
            {
                PlayerPrefs.SetInt("bestScore", currentScoreVal);
                best.text = PlayerPrefs.GetInt("bestScore").ToString();
            }
            GetComponent<SpriteRenderer>().color = landedColor;
            platformAnim.SetTrigger("Trigger");
            scoreAnim.SetTrigger("Trigger");
            audioSource.PlayOneShot(sound);
            difficulty.ModDifficulty();
            if (currentScoreVal % 20 == 0)
            {
                comet.ActivateComet();
            }
            //check for achievments
            switch (PlayerPrefs.GetInt("currentScore"))
            {
                case 5:
                    PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAC");
                    break;
                case 20:
                    PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAD");
                    break;
                case 50:
                    PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAE");
                    break;
                case 100:
                    PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAI");
                    break;
                case 200:
                    PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAJ");
                    break;
                case 500:
                    PlayGamesScript.UnlockAchievement("CggI5crG7DEQAhAK");
                    break;
            }
        }
    }
}
