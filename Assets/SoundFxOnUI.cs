using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundFxOnUI : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.AshkanSwooshSfx);
    }

    public void OnPointerDown(PointerEventData ped)
    {
      //  SoundManager.Play("MouseClickButton");
    }
}