﻿using System.Collections;
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
            if (piece.isPlaced == true)
                boardScript.placePieceOnBoard(piece, x, y, 0);
            if (boardScript.PlacePiece(piece, x, y))
            {
                Debug.Log("snaps");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                if (boardScript.Completed())
                {
                    print("THE END");
                }

            }

        }
    }
}
