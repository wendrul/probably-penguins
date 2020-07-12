using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int x;
    public int y;
    public GameObject board;
    private Board boardScript;
   

    void Start()
    {
       boardScript = board.GetComponent<Board>();
    }
       public void OnDrop(PointerEventData eventData)
    {
     //   Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            Piece piece = eventData.pointerDrag.GetComponent<Piece>();
            if (boardScript.PlacePiece(piece, x, y))
            {
                AudioManager.Instance.PlaySFX(GameAssets.i.SnapBouz, 0.15f);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition  + new Vector2(0, boardScript.puzzleDone * -1000);
                if (boardScript.Completed())
                {
                    

                }

            }

        }
    }
}
