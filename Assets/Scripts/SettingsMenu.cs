using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public void SaveGame()
    {
        int savedScene = PlayerPrefs.GetInt("LastPlayedScene", 0);
        PlayerPrefs.SetInt("Scene", savedScene);
        PlayerPrefs.Save();

        Debug.Log("Oyun kaydedildi: Sahne " + savedScene);

    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            int sceneToLoad = PlayerPrefs.GetInt("Scene");
            SceneManager.LoadScene(sceneToLoad);

            Debug.Log("Kayıt yüklendi: Sahne " + sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Kayıtlı sahne bulunamadı.");
        }

    }

    public void ClearGame()
    {
        PlayerPrefs.DeleteKey("SavedScene");
        PlayerPrefs.Save();
        Debug.Log("Kayıt silindi.");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}