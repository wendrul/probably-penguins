using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundFxOnUI : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.AshkanSwooshSfx, 1.4f);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData ped)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void OnPointerDown(PointerEventData ped)
    {
      //  SoundManager.Play("MouseClickButton"); 
    }
}