using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject board;
    private Board boardScript;
    public GameObject tetriminos;
    private CanvasGroup tetriminosCg;

    void Start()
    {
        boardScript = board.GetComponent<Board>();
        tetriminosCg = tetriminos.GetComponent<CanvasGroup>();
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.TakePiecesfx, 0.15f);
        //   Debug.Log("OnBeginDrag");
        Piece piece = eventData.pointerDrag.GetComponent<Piece>();
        if (eventData.pointerDrag != null)
        {
             if (piece.isPlaced == true)
              boardScript.placePieceOnBoard(piece, piece.x, piece.y, 0);
        }

        Vector2 localPoint = new Vector2(0, 0);
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, camera, out localPoint);
        rectTransform.position = Input.mousePosition;
       // rectTransform.anchoredPosition = localPoint;
        canvasGroup.alpha = .5f;
        tetriminosCg.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //     Debug.Log("OnDrag");
       
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor / 1.528331f;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    //    Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        tetriminosCg.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
   //     Debug.Log("OnPointerDown");
    }
}
