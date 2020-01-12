using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionScreenReportCreator : ReportCreatorScreen
{
    [SerializeField] private Selectable firstSelected;
    [SerializeField] private ReportData data;

    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text pageNumber;

    [SerializeField] private HistoricReportCreator historic;
    [SerializeField] private ObjectPicker picker;

    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    public int currentQuestion;

    public delegate void ReceiveReport(List<ScriptableObject> list);
    public event ReceiveReport receiveReport;

    public override void OnOpen()
    {
        historic.Initialize();
        firstSelected.Select();
        data = FindObjectOfType<ReportCreator>().GetReportData();
        base.OnOpen();
        currentQuestion = 0;

        UpdateQuestion();
    }
    public override void OnClose()
    {
        base.OnClose();
    }
    public void UpdateQuestion()
    {
        UpdatePageNumber();

        question.text = data.questions[currentQuestion].question;
        picker.ResetPicker();
        firstSelected.Select();
        prevButton.interactable = currentQuestion != 0;

        if (currentQuestion == data.questions.Count - 1)
            nextButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "FINALIZAR";
        else
            nextButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "PRÓXIMA";
    }
    public void End()
    {
        receiveReport(historic.answers);
    }
    public void NextQuestion()
    {
        historic.AddAnswer(currentQuestion, picker.GetSelectedObject(), picker.GetSelectedType());
        currentQuestion++;
        if (currentQuestion < data.questions.Count)
            UpdateQuestion();
        else
            End();
    }
    public void PreviousQuestion()
    {
        currentQuestion = Mathf.Clamp(currentQuestion - 1, 0, data.questions.Count);
        UpdateQuestion();
    }
    public void UpdatePageNumber()
    {
        pageNumber.text = (currentQuestion + 1) + "/" + data.questions.Count;
    }
}
