using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject everything;
    public int puzzleDone = 0;
    private int i;

    public int[,] tab = new int[,] { { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 0, 0, 1 } };
    public int[,] tab1 = new int[,] { { 1, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 1, 0, 0, 0 } };
    public int[,] tab2 = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
    public int[,] tab3 = new int[,] { { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 1, 0, 1 } };

    public int[,] tab4 = new int[,] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 } };
    public int[,] tab5 = new int[,] { { 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 1, 1, 0, 0 }, { 0, 1, 1, 0, 0 }, { 0, 0, 0, 0, 0 } };
    public int[,] tab6 = new int[,] { { 1, 1, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 1 } };
    public int[,] tab7 = new int[,] { { 1, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 0 }, { 1, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 } };
    public int[,] tab8 = new int[,] { { 1, 0, 1, 1, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 } };

    public int[,] tab9 = new int[,]  { { 0, 0, 0, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } };
public int[,] tab10 = new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 1, 0, 1, 0, 0 }, { 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0, 0 } };


    public bool PlacePiece(Piece piece, int x, int y)
    {
        if (x < 0 || y < 0 || x >= tab.GetLength(0) || y >= tab.GetLength(1))
            return (false);
        if (tab[x, y] == 0)
        {
            i = -1;
            int a = x;
            int b = y;
            if (x < 0 || y < 0 || x >= tab.GetLength(0) || y >= tab.GetLength(1))
                return (false);
            while (++i < 3)
            {
                if (!CheckPiece(piece.shapePath[i], ref x, ref y))
                    return (false);
            }
             placePieceOnBoard(piece, a, b, 1);
            return (true);
        }
        return (false);
    }

    public void placePieceOnBoard(Piece piece, int x, int y, int number)
    {
        if (piece.isPlaced == false)
        {
            piece.isPlaced = true;
            piece.x = x;
            piece.y = y;
        }
        else
            piece.isPlaced = false;
        tab[x, y] = number;
        i = -1;
        while (++i < 3)
        {
            if (piece.shapePath[i] == 'u')
                y -= 1;
            if (piece.shapePath[i] == 'd')
                y += 1;
            if (piece.shapePath[i] == 'r')
                x += 1;
            if (piece.shapePath[i] == 'l')
                x -= 1;
            if (piece.shapePath[i] == 'a')
            {
                x -= 1;
                y -= 1;
            }
            if (piece.shapePath[i] == 'e')
            {
                x += 1;
                y -= 1;
            }
            if (piece.shapePath[i] == 'w')
            {
                x -= 1;
                y += 1;
            }
            if (piece.shapePath[i] == 'c')
            {
                x += 1;
                y += 1;
            }
            tab[x, y] = number;
        }
    }

    bool CheckPiece(char piece, ref int x, ref int y)
    {
        if (x < 0 || y < 0 || x >= tab.GetLength(0) || y >= tab.GetLength(1))
            return (false);
        if (piece == 'u')
            y -= 1;
        if (piece == 'd')
            y += 1;
        if (piece == 'r')
            x += 1;
        if (piece == 'l')
            x -= 1;
        if (piece == 'a')
        {
            x -= 1;
            y -= 1;
        }
        if (piece == 'e')
        {
            x += 1;
            y -= 1;
        }
        if (piece == 'w')
        {
            x -= 1;
            y += 1;
        }
        if (piece == 'c')
        {
            x += 1;
            y += 1;
        }
        if (x < 0 || y < 0 || x >= tab.GetLength(0) || y >= tab.GetLength(1))
            return (false);
        if (tab[x, y] != 0)
            return (false);
        return (true);
    }



    public bool Completed()
    {
        for (int i = 0; i < tab.GetLength(0); i++)
        {
            for (int j = 0; j < tab.GetLength(1); j++)
            {
                if (tab[i, j] == 0)
                    return (false);
            }
        }
        puzzleDone++;
        if (puzzleDone == 1)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab1;
        }
        if (puzzleDone == 2)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab2;
        }
        if (puzzleDone == 3)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab3;
        }
        if (puzzleDone == 4)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab4;
        }
        if (puzzleDone == 5)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab5;
        }
        if (puzzleDone == 6)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab6;
        }
        if (puzzleDone == 7)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab7;
        }
        if (puzzleDone == 8)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab8;
        }
        if (puzzleDone == 9)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab9;
        }
        if (puzzleDone == 10)
        {
            everything.GetComponent<Transform>().position += new Vector3(0, 1000 * 2.06f, 0);
            tab = tab10;
        }

        return (true);
    }
}