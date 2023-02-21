using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Text _ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Set Score to 0.
        _ScoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        _ScoreText.text = "Score: " + playerScore;
    }
}
