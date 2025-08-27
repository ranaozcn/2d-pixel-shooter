using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            int savedSceneIndex = PlayerPrefs.GetInt("Scene");
            SceneManager.LoadScene(savedSceneIndex);
            Debug.Log("Kayıttan devam ediliyor: Sahne " + savedSceneIndex);
        }
        else
        {
            Debug.LogWarning("Kayıtlı sahne bulunamadı.");
        }

    }
    public void Settings()
    {
        SceneManager.LoadScene(6);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
