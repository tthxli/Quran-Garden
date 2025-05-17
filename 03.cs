using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGameController : MonoBehaviour
{
    public Text questionText;
    public Text scoreText;
    public Text timeText;
    public Button[] answerButtons;
    public Button backBtn;
    
    private string[] questions = {
        "سوره‌ای که با 'بسم الله الرحمن الرحیم' شروع می‌شود؟",
        "سوره‌ای که درباره توحید است؟",
        "سوره‌ای که به 'قل هو الله احد' معروف است؟"
    };
    
    private string[][] answers = {
        new string[] {"حمد", "توحید", "ناس", "فلق"},
        new string[] {"توحید", "حمد", "کوثر", "ناس"},
        new string[] {"توحید", "حمد", "فلق", "ناس"}
    };
    
    private int[] correctAnswers = {0, 0, 0};
    private int currentQuestion = 0;
    private int score = 0;
    private float timeLeft = 30f;
    private bool gameActive = true;

    void Start()
    {
        backBtn.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        SetupQuestion();
        StartCoroutine(Timer());
    }

    void SetupQuestion()
    {
        questionText.text = questions[currentQuestion];
        
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answers[currentQuestion][i];
            int index = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int answerIndex)
    {
        if (!gameActive) return;
        
        if (answerIndex == correctAnswers[currentQuestion])
        {
            score += 10;
            scoreText.text = "امتیاز: " + score;
        }
        else
        {
            score = Mathf.Max(0, score - 5);
            scoreText.text = "امتیاز: " + score;
        }
        
        NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestion++;
        if (currentQuestion < questions.Length)
        {
            SetupQuestion();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameActive = false;
        questionText.text = "بازی تمام شد! امتیاز نهایی: " + score;
        foreach (Button btn in answerButtons)
        {
            btn.gameObject.SetActive(false);
        }
    }

    IEnumerator Timer()
    {
        while (timeLeft > 0 && gameActive)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "زمان: " + Mathf.RoundToInt(timeLeft);
            yield return null;
        }
        
        if (gameActive)
        {
            EndGame();
        }
    }
}