using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string currentScene;
    public int bulletsUsed;
    public int bulletsLeft;
    public Vector3 playerPosition;
    public GameObject player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SaveGame()
    {
        
        if (player == null)
        {
            Debug.Log("Oyun Kaydedilmedi");
            return;
        }

        PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);

        PlayerPrefs.SetInt("bulletsUsed", bulletsUsed);
        PlayerPrefs.SetInt("bulletsLeft", bulletsLeft);

        PlayerPrefs.SetFloat("PositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("PositionZ", player.transform.position.z);

        PlayerPrefs.Save();
        Debug.Log("Oyun Kaydedildi!");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            currentScene = PlayerPrefs.GetString("Scene");

            bulletsUsed = PlayerPrefs.GetInt("bulletsUsed");
            bulletsLeft = PlayerPrefs.GetInt("bulletsLeft");

            float x = PlayerPrefs.GetFloat("PositionX");
            float y = PlayerPrefs.GetFloat("PositionY");
            float z = PlayerPrefs.GetFloat("PositionZ");
            playerPosition = new Vector3(x, y, z);

            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(currentScene);

        }
        else
        {
            Debug.LogWarning("Kayıt bulunamadı!");
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerPosition;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("Oyun Yüklendi!");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Tüm kayıtlar silindi!");
    }
}
