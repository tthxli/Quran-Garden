using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Buttons")]
    public Button startGameBtn;
    public Button storiesBtn;
    public Button miniGameBtn;
    public Button settingsBtn;
    public Button aboutBtn;
    
    [Header("Audio")]
    public AudioSource bgMusic;
    public Toggle musicToggle;

    void Start()
    {
        // تنظیم اولیه صدا
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            bgMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
            musicToggle.isOn = bgMusic.volume > 0;
        }
        else
        {
            bgMusic.volume = 0.5f;
            musicToggle.isOn = true;
        }

        // تنظیم رویدادهای دکمه‌ها
        startGameBtn.onClick.AddListener(() => LoadScene("MainGame"));
        storiesBtn.onClick.AddListener(() => LoadScene("QuranStories"));
        miniGameBtn.onClick.AddListener(() => LoadScene("MiniGame"));
        settingsBtn.onClick.AddListener(() => LoadScene("Settings"));
        aboutBtn.onClick.AddListener(() => LoadScene("AboutUs"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleMusic(bool isOn)
    {
        bgMusic.volume = isOn ? 0.5f : 0f;
        PlayerPrefs.SetFloat("MusicVolume", bgMusic.volume);
    }
}