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
    }
}
