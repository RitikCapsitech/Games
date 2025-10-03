using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // if you want to show score on UI

public class Score : MonoBehaviour
{
    
    public int points = 0;
    public int level = 1;
    public Manager manager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Message;
    public TextMeshProUGUI Points;
    public GameObject NextLevel;
    public GameObject endPanel;
    public TextMeshProUGUI Level;

    public void AddPoints(string shapeTag)
    {
        switch (shapeTag)
        {
            case "Circle":
                points += 5;

                ShowPoints("+5 Points");

                break;
            case "Triangle":
                points -= 3;
                ShowPoints( "-3 Points");
                break;
            case "Capsule":
                points -= 2;
                ShowPoints("-2 Points");
                break;
        }

        // Update UI if assigned
        if (scoreText != null)
            scoreText.text = "SCORE: " + points +"/30";
        // Check Win/Lose
        if (points < 0)
        {
            //ShowEndPanel("You Lose! Final Score: " + points);
            ShowEndPanel("You Lose! " );
            NextLevel.SetActive(false);
        }
       
        else if (points >= 30)
        {
            if (level < 5)
            {
                ShowEndPanel("Level " + level + " Complete!");
                NextLevel.SetActive(true); // show next level button
            }
            else
            {
                ShowEndPanel("You Completed All Levels!");
                NextLevel.SetActive(false);
            }
        }
    }
    public void RetryLevel()
    {
        points = 0; // reset score
        scoreText.text = "SCORE: " + points + "/30";

        // hide panel and resume
        if (endPanel != null)
            endPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void NextLevelGame()
    {
        if (level < 5)
        {
            level++;
            points = 0; // reset score
            scoreText.text = "SCORE: " + points + "/30";
            Level.text = "Level " + level;

            if (manager != null)
                manager.DecreaseSpawnInterval();

            // Hide panel & resume game
            if (endPanel != null)
                endPanel.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    void ShowPoints(string text)
    {
        if (Points != null)
        {
            Points.text = text;
            Points.gameObject.SetActive(true);
            CancelInvoke(nameof(HidePoints)); // clear old invokes
            Invoke(nameof(HidePoints), 0.5f);   // hide after 2 second
        }
    }

    void HidePoints()
    {
        if (Points != null)
            Points.gameObject.SetActive(false);
    }
    void ShowEndPanel(string text)
    {
        if (Message != null)
            Message.text = text;

        if (endPanel != null)
            endPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }
    // Restart button logic
    public void RestartGame()
    {
        // Resume time
        Time.timeScale = 1f;

        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit button logic
    public void QuitGame()
    {
        // If standalone build
        Application.Quit();

        //If testing in editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    
}
