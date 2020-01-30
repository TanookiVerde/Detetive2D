using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InvestigationSpotUI : MenuBehaviour
{
    [SerializeField] private CanvasGroup group;
    [SerializeField] private Image background;
    [SerializeField] private InvestigationSpotData spotData;

    [Header("Lines")]
    [SerializeField] private RectTransform boardXBound;
    [SerializeField] private RectTransform boardYBound;
    [SerializeField] private RectTransform verticalLine;
    [SerializeField] private RectTransform horizontalLine;
    [SerializeField] private float lineSpeed;

    public override void OnOpen()
    {
        ResetLinesPosition();
    }
    public void SetInfo(InvestigationSpotData data)
    {
        background.sprite = data.background;
        spotData = data;
    }
    public override void OnClose(){}
    public override void Loop()
    {
        MoveLinesByInput();
        if (Input.GetKeyDown(KeyCode.X))
            spotData.Investigate(GetNormalizedPosition());
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
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
