using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class MovingPuzzleUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool finish;
    private Vector2 initialPosition;
    private Coroutine moveCoroutine;

    public GameObject form;
    private Vector2 formStartPosition;
    private Vector2 startPosition; // Добавим для рестарта

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPosition = rectTransform.anchoredPosition; // Сохраняем стартовую позицию

        if (form != null)
            formStartPosition = form.GetComponent<RectTransform>().anchoredPosition;
    }

    public void ResetPiece()
    {
        finish = false;
        rectTransform.anchoredPosition = startPosition;
        GetComponent<Image>().raycastTarget = true;

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }

        // Корректируем счетчик элементов
        if (PuzzleManager.myElement > 0 && this.finish)
        {
            PuzzleManager.myElement--;
        }
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (finish) return;

        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (finish) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint);

        rectTransform.anchoredPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (finish) return;

        if (form != null &&
           Vector2.Distance(rectTransform.anchoredPosition, formStartPosition) <= 10f)
        {
            FinishPuzzle();
        }
    }

    void FinishPuzzle()
    {
        finish = true;
        moveCoroutine = StartCoroutine(SmoothMoveToForm());
        GetComponent<Image>().raycastTarget = false;
        PuzzleManager.AddElement();
    }

    private IEnumerator SmoothMoveToForm()
    {
        Vector2 currentVelocity = Vector2.zero;
        while (Vector2.Distance(rectTransform.anchoredPosition, formStartPosition) > 0.1f)
        {
            rectTransform.anchoredPosition = Vector2.SmoothDamp(
                rectTransform.anchoredPosition,
                formStartPosition,
                ref currentVelocity,
                0.1f);
            yield return null;
        }
    }
}