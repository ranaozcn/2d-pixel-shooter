using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameScreen : MonoBehaviour
{
    
    public GameObject inGameScreen, pauseScreen;
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void SaveButton()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastPlayedScene", currentSceneIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(6);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void StartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
