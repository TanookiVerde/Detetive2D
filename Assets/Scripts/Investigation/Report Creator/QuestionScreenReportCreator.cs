﻿using System.Collections;
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

    public override void OnOpen()
    {
        historic.Initialize();
        firstSelected.Select();
        data = FindObjectOfType<ReportCreator>().GetReportData();
        base.OnOpen();
        currentQuestion = 0;

        Begin();
    }
    public override void OnClose()
    {
        base.OnClose();
    }
    public void Begin()
    {
        UpdatePageNumber();
        question.text = data.questions[currentQuestion].question;
        picker.ResetPicker();
        prevButton.interactable = currentQuestion != 0;
    }
    public void End()
    {
        foreach(var a in historic.answers)
        {
            print(a.name);
        }
    }
    public void NextQuestion()
    {
        historic.AddAnswer(currentQuestion, picker.GetSelectedObject(), picker.GetSelectedType());
        currentQuestion++;
        if (currentQuestion < data.questions.Count)
            Begin();
        else
            End();
    }
    public void PreviousQuestion()
    {
        currentQuestion = Mathf.Clamp(currentQuestion - 1, 0, data.questions.Count);
        Begin();
    }
    public void UpdatePageNumber()
    {
        pageNumber.text = currentQuestion + "/" + (data.questions.Count - 1);
    }
}
