using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Text _ScoreText;
    [SerializeField]
    private Sprite[] _LiveSprites;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Text _GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        // Set Score to 0.
        _ScoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        // Update score.
        _ScoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int CurrentLives)
    {
        // Update lives.
        _LivesImg.sprite = _LiveSprites[CurrentLives];

        // If CurrentLives is 0:
        if (CurrentLives == 0)
        {
            // Turn on Gameover text.
            _GameOverText.gameObject.SetActive(true);

            // Start gameover text flicker.
            StartCoroutine(GameoverFlickerRoutine());
        }
    }

    IEnumerator GameoverFlickerRoutine()
    {
        // Infinite loop:
        while (true)
        {
            // Set Gameover Text to game over.
            _GameOverText.text = "GAME OVER";

            // Wait for 0.5 seconds.
            yield return new WaitForSeconds(0.5f);

            // Set game over text to nothing.
            _GameOverText.text = "";

            // Wait 0.5 seconds.
            yield return new WaitForSeconds(0.5f);
        }
    }
}