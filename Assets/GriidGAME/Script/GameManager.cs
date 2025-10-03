using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Grid Settings")]
    public GridManager gridManager;
    public GridDataSO gridDataSO;
    public int currentLevel = 1;
    private bool isLevelComplete = false;

    [Header("UI References")]
    public GameObject levelCompletePanel;
    public TextMeshProUGUI levelCompleteText;
    public Button nextLevelButton;
    public Button restartButton;
    public Button retryButton;

    [Header("Game UI (Always Visible)")]
    public TextMeshProUGUI currentLevelText;  // Shows "Level 1" during gameplay

    private void Start()
    {
        // Hide the level complete panel at start
        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);
        }

        // Setup button listeners
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartClicked);
        }
        if (retryButton != null)
        {
            retryButton.onClick.AddListener(OnRetryClicked);
        }
        StartLevel();
    }

    private void Update()
    {
        if (!isLevelComplete && gridManager.IsGridFull())
        {
            isLevelComplete = true;
            Debug.Log("Level " + currentLevel + " complete!");
            ShowLevelComplete();
        }
    }

    public void StartLevel()
    {
        isLevelComplete = false;
        gridManager.gridSize = currentLevel + 1; // Level 1 = 2x2, Level 2 = 3x3...
        gridManager.GenerateGrid();
        HideLevelComplete();
        UpdateCurrentLevelDisplay();  // ✅ Update the level display
    }

    private void ShowLevelComplete()
    {
        Debug.Log("ShowLevelComplete called for level " + currentLevel);

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true);
            Debug.Log("Panel activated!");
        }
        else
        {
            Debug.LogError("levelCompletePanel is NULL!");
        }

        if (levelCompleteText != null)
        {
            if (currentLevel >= 5)
            {
                levelCompleteText.text = "All Levels Complete!\nYou Win!";
                if (nextLevelButton != null)
                {
                    nextLevelButton.gameObject.SetActive(false);
                }
            }
            else
            {
                levelCompleteText.text = $"Level {currentLevel} Complete!";
                if (nextLevelButton != null)
                {
                    nextLevelButton.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Debug.LogError("levelCompleteText is NULL!");
        }
    }

    private void HideLevelComplete()
    {
        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);
        }
    }

    private void UpdateCurrentLevelDisplay()
    {
        if (currentLevelText != null)
        {
            currentLevelText.text = $"Level {currentLevel}";
        }
    }

    private void OnNextLevelClicked()
    {
        if (currentLevel < 5)
        {
            currentLevel++;
            StartLevel();
        }
        else
        {
            Debug.Log("All 5 levels complete!");
        }
    }

    private void OnRestartClicked()
    {
        currentLevel = 1;
        StartLevel();
    }

    public void ResetLevel()
    {
        StartLevel();
    }

    public void RestartGame()
    {
        currentLevel = 1;
        StartLevel();
    }
    private void OnRetryClicked()
    {
        StartLevel();  // Restart the same level (doesn't change currentLevel)
    }
}