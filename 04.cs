using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AboutUsController : MonoBehaviour
{
    public Text infoText;
    public Button backButton;

    void Start()
    {
        infoText.text = "بازی آموزشی قرآن کریم\n\n" +
                       "طراح: سیده فاطمه حسینی\n" +
                       "استان: گلستان\n" +
                       "دانشگاه: فرهنگیان امام خمینی (ره) گرگان\n\n" +
                       "این بازی برای جشنواره قرآن و عترت طراحی شده است.\n" +
                       "کلیه حقوق محفوظ است - ۱۴۰۳";

        backButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}