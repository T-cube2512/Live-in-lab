using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionAskManager : MonoBehaviour
{
    public Text questionText;
    public Text[] choiceTexts;
    public Text timerText;
    public Text averageTimeText;
    [SerializeField]
    private QuestionArrangeManager questionArrangeManager;
    [SerializeField]
    private Question[] questions;
    [SerializeField]
    private float totalTime = 60f;
    private float remainingTime;
    private float questionStartTime;
    private int questionsSolved = 0;
    private float totalSolveTime = 0f;

    void Start()
    {
        questionArrangeManager = FindObjectOfType<QuestionArrangeManager>();
        remainingTime = totalTime;
        StartCoroutine(Timer());
        questions = questionArrangeManager.questions;
        Debug.Log(questionArrangeManager.questions);
        AskRandomQuestion();
    }

    void AskRandomQuestion()
    {
        if (remainingTime <= 0)
        {
            EndQuiz();
            return;
        }
        Debug.Log(questions.Length);
        Question question = questions[Random.Range(0, questions.Length-1)];
        questionText.text = question.question;

        for (int i = 0; i < choiceTexts.Length; i++)
        {
            if (i < question.choices.Length)
            {
                choiceTexts[i].text = question.choices[i].choiceString;
                choiceTexts[i].transform.parent.gameObject.SetActive(true);
            }
            else
            {
                choiceTexts[i].transform.parent.gameObject.SetActive(false);
            }
        }

        questionStartTime = Time.time;
    }

    public void OnChoiceSelected(int index)
    {
        if (questions.Length == 0)
            return;

        Question question = questions[Random.Range(0, questions.Length)];
        if (question.choices[index].choiceValue)
        {
            float solveTime = Time.time - questionStartTime;
            questionsSolved++;
            totalSolveTime += solveTime;
        }

        AskRandomQuestion();
    }

    IEnumerator Timer()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(remainingTime).ToString();
            yield return null;
        }

        EndQuiz();
    }

    void EndQuiz()
    {
        StopAllCoroutines();
        float averageSolveTime = questionsSolved > 0 ? totalSolveTime / questionsSolved : 0f;
        averageTimeText.text = "Average Time: " + averageSolveTime.ToString("F2") + " seconds";
    }
}
