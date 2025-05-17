using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button backBtn;
    public Toggle vibrationToggle;

    void Start()
    {
        // بارگذاری تنظیمات ذخیره شده
        musicSlider.value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 0.5f;
        sfxSlider.value = PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") : 0.7f;
        vibrationToggle.isOn = PlayerPrefs.HasKey("Vibration") ? PlayerPrefs.GetInt("Vibration") == 1 : true;

        // تنظیم رویدادها
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        vibrationToggle.onValueChanged.AddListener(SetVibration);
        backBtn.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        // اینجا می‌توانید حجم موسیقی پس‌زمینه را تنظیم کنید
    }

    void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        // اینجا می‌توانید حجم صداهای افکت را تنظیم کنید
    }

    void SetVibration(bool value)
    {
        PlayerPrefs.SetInt("Vibration", value ? 1 : 0);
    }
}