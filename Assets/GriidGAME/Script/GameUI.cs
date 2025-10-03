//using UnityEngine;
//using TMPro;
//using UnityEngine.UI;

//public class GameUI : MonoBehaviour
//{
//    [Header("UI References")]
//    public GameObject levelCompletePanel;  // Panel that shows when level is complete
//    public TextMeshProUGUI levelCompleteText;  // Text showing "Level X Complete!"
//    public Button nextLevelButton;
//    public Button restartButton;

//    [Header("References")]
//    public GameManager gameManager;

//    private void Start()
//    {
//        // Hide the level complete panel at start
//        if (levelCompletePanel != null)
//        {
//            levelCompletePanel.SetActive(false);
//        }

//        // Setup button listeners
//        if (nextLevelButton != null)
//        {
//            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
//        }

//        if (restartButton != null)
//        {
//            restartButton.onClick.AddListener(OnRestartClicked);
//        }
//    }

//    public void ShowLevelComplete(int level)
//    {
//        if (levelCompletePanel != null)
//        {
//            levelCompletePanel.SetActive(true);
//        }

//        if (levelCompleteText != null)
//        {
//            if (level >= 5)
//            {
//                levelCompleteText.text = "All Levels Complete!\nYou Win!";
//                // Hide next level button on final level
//                if (nextLevelButton != null)
//                {
//                    nextLevelButton.gameObject.SetActive(false);
//                }
//            }
//            else
//            {
//                levelCompleteText.text = $"Level {level} Complete!";
//                // Show next level button
//                if (nextLevelButton != null)
//                {
//                    nextLevelButton.gameObject.SetActive(true);
//                }
//            }
//        }
//    }

//    public void HideLevelComplete()
//    {
//        if (levelCompletePanel != null)
//        {
//            levelCompletePanel.SetActive(false);
//        }
//    }

//    private void OnNextLevelClicked()
//    {
//        HideLevelComplete();
//        // GameManager will automatically start next level in Update()
//    }

//    private void OnRestartClicked()
//    {
//        HideLevelComplete();
//        if (gameManager != null)
//        {
//            gameManager.RestartGame();
//        }
//    }
//}