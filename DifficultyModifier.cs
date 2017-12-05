using UnityEngine;

public class DifficultyModifier : MonoBehaviour {

    PlayerController playerController;
    public float difficultyModifier;
    float startSpeed;

    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        startSpeed = playerController.xVel;
    }

    public void ModDifficulty () {
        if (playerController.grounded)
        {
            playerController.xVel = startSpeed + Mathf.Sqrt(Camera.main.transform.position.y) * difficultyModifier;
            playerController.jumpForce = 10f / (PlayerPrefs.GetInt("currentScore") + 10f) + 26f;
        }
    }
}
