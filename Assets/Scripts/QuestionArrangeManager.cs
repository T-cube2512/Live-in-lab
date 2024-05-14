using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class QuestionArrangeManager : MonoBehaviour
{
    public string jsonFileName = "questions.json";
    public Question[] questions;

    [System.Serializable]
    public class QuestionContainer
    {
        public Question[] questions;
    }

    void Start()
    {
        LoadQuestionsFromJson();
    }

    void LoadQuestionsFromJson()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            QuestionContainer questionContainer = JsonUtility.FromJson<QuestionContainer>(jsonContent);
            questions = questionContainer.questions;
        }
        else
        {
            Debug.LogError("Cannot find file: " + filePath);
        }
    }
}
