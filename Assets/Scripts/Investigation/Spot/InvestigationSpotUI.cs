using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InvestigationSpotUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;
    [SerializeField] private Image background;
    [SerializeField] private InvestigationSpotData spotData;

    private Coroutine loopCoroutine;

    [Header("Lines")]
    [SerializeField] private RectTransform boardXBound;
    [SerializeField] private RectTransform boardYBound;
    [SerializeField] private RectTransform verticalLine;
    [SerializeField] private RectTransform horizontalLine;
    [SerializeField] private float lineSpeed;

    public void Open(InvestigationSpotData data)
    {
        GlobalFlags.onInvestigationSpot = true;

        group.alpha = 1;
        background.sprite = data.background;
        spotData = data;
        ResetLinesPosition();

        loopCoroutine = StartCoroutine(Loop());
    }
    public void Close()
    {
        GlobalFlags.onInvestigationSpot = false;

        group.alpha = 0;

        StopCoroutine(loopCoroutine);
    }
    private IEnumerator Loop()
    {
        yield return null;
        while (true)
        {
            MoveLinesByInput();
            if (Input.GetKeyDown(KeyCode.X))
                Investigate(GetNormalizedPosition());
            if (Input.GetKeyDown(KeyCode.Escape))
                Close();
            yield return null;
        }
    }
    public void Investigate(Vector2 normalizedPosition)
    {
        foreach (var s in spotData.clues)
        {
            if((normalizedPosition - s.position).magnitude <= s.colliderSize)
            {
                print(s.position + "/" + normalizedPosition);
                FoundClue(s.clue);
                return;
            }
        }
        NoClueFound();
    }
    private void FoundClue(ClueData clue)
    {
        CaseData openedCase = InvestigationManager.GetCase();
        Files files = Files.Load();
        bool added = files.AddClue(openedCase.GetClueIndexFromData(clue));
        files.Save();
        DialogUI.StartDialog(clue.findingDialog, added, DialogType.CLUE);
    }
    private void NoClueFound()
    {
        var speech = new List<string>();
        speech.Add("MARTHA: Não tem nada suspeito nisso.");
        DialogUI.StartDialog(speech);
    }
    public void MoveLinesByInput()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * lineSpeed;
        if (direction.x != 0)
        {
            float newPosition = verticalLine.anchoredPosition.x + direction.x;
            newPosition = Mathf.Clamp(newPosition,
                boardXBound.anchoredPosition.x,
                -boardXBound.anchoredPosition.x);
            verticalLine.DOAnchorPosX(newPosition, 0);
        }
        if (direction.y != 0)
        {
            float newPosition = horizontalLine.anchoredPosition.y + direction.y;
            newPosition = Mathf.Clamp(newPosition,
                boardYBound.anchoredPosition.y,
                -boardYBound.anchoredPosition.y);
            horizontalLine.DOAnchorPosY(newPosition, 0);
        }
    }
    public Vector2 GetCursorPosition()
    {
        return new Vector2(verticalLine.anchoredPosition.x, horizontalLine.anchoredPosition.y);
    }
    public Vector2 GetBoardSize()
    {
        var x = Mathf.Abs(boardXBound.anchoredPosition.x) * 2;
        var y = Mathf.Abs(boardYBound.anchoredPosition.y) * 2;
        return new Vector2(x,y);
    }
    public Vector2 GetNormalizedPosition()
    {
        var pos = GetCursorPosition();
        var size = GetBoardSize();
        return new Vector2(pos.x / size.x, pos.y / size.y);
    }
    public void ResetLinesPosition()
    {
        verticalLine.DOAnchorPosX(0, 0);
        horizontalLine.DOAnchorPosY(0, 0);
    }
}
