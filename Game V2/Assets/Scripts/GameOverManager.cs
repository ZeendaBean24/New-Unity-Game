using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false); // Hide game over screen initially
    }

    public void ShowGameOverScreen()
    {
        gameOverCanvas.SetActive(true); // Show game over screen
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
