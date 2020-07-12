using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShield : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void Pause()
    {
        Cursor.visible = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
    }

    public void Loop()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
