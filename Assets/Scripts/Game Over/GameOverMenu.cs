using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable() {
        PlayerController.onPlayerDeath += enableGameOverMenu;
    }

    private void OnDisable() {
        PlayerController.onPlayerDeath -= enableGameOverMenu;
    }

    public void enableGameOverMenu() {
        gameOverMenu.SetActive(true);
    }

    public void retryGame() {
        SceneManager.LoadScene("SampleScene");
    }
    public void goToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame() {
        Application.Quit();
    }
}
