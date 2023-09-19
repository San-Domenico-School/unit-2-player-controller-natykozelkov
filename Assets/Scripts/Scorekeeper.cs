using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText;
    private float score;
    private int penalty = 40;

    public static Scorekeeper Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }

    // Inputs vertical input value received from the playerController script to an exponential
    // function whose values range from 0.00 to 0.35 which is then added to the score before
    // calling the DisplayScore method
    public void AddToScore(float inputFromPlayer)
    {
        // Calculate score increase based on input (placeholder logic)
        float scoreIncrease = Mathf.Clamp01(inputFromPlayer) * 0.35f;

        // Add the score increase
        score += scoreIncrease;

        // Call the method to display the updated score
        DisplayScore();
    }

    // Subtracts penalty from the score to no less than zero when the player runs into an obstacle.
    // before calling the DisplayScore method
    public void SubtractFromScore()
    {
        // Subtract the penalty from the score
        score -= penalty;

        // Ensure the score is not negative
        score = Mathf.Max(score, 0);

        // Call the method to display the updated score
        DisplayScore();
    }

    // Displays score to UI rounded to nearest integer
    public void DisplayScore()
    {
        // Round the score to the nearest integer
        int roundedScore = Mathf.RoundToInt(score);

        // Update the TextMeshProUGUI text with the rounded score
        scoreboardText.text = "Score: " + roundedScore.ToString();
    }
}

