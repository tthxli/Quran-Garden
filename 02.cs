using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    [System.Serializable]
    public class QuranStory
    {
        public string title;
        [TextArea(3,10)] public string content;
        public Sprite image;
    }

    public List<QuranStory> stories;
    public Text titleText;
    public Text contentText;
    public Image storyImage;
    public Button nextBtn;
    public Button prevBtn;
    public Button backBtn;

    private int currentStory = 0;

    void Start()
    {
        UpdateStory();
        
        nextBtn.onClick.AddListener(NextStory);
        prevBtn.onClick.AddListener(PrevStory);
        backBtn.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    void UpdateStory()
    {
        titleText.text = stories[currentStory].title;
        contentText.text = stories[currentStory].content;
        storyImage.sprite = stories[currentStory].image;
        
        prevBtn.interactable = currentStory > 0;
        nextBtn.interactable = currentStory < stories.Count - 1;
    }

    void NextStory()
    {
        if (currentStory < stories.Count - 1)
        {
            currentStory++;
            UpdateStory();
        }
    }

    void PrevStory()
    {
        if (currentStory > 0)
        {
            currentStory--;
            UpdateStory();
        }
    }
}