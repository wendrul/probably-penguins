using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Book : MonoBehaviour
{
    int i;
    private GameObject[] page;
    public bool PageWasPlayed { get; set; }
    public bool ShouldEnd { get; set; }


    private void Start()
    {
        ShouldEnd = false;
        page = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            page[i] = transform.GetChild(i).gameObject;
        }
        i = 15;
        Pause();
    }

    public void NextPage()
    {
        if (i < transform.childCount - 2)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            i++;
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (i > 0)
        {       
            transform.GetChild(i).gameObject.SetActive(false);
            i--;
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void BinbinFather()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 1;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
    }

    public void CryingInBed()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 2;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
    }

    public void Hospital()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 3;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
    }

    public void GranfatherFlashback()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 4;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
    }

    public void DreamingHappy()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 5;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }

    public void AloneInTheDark()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 6;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }
    public void FishGiantFish()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 7;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;

    }
    public void LookGiantFish()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 8;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }
    public void SpeedDating()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 9;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
    }
    public void Cliff()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 10;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
    }
    public void PingHell()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 11;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }
    public void TenOutTen()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 12;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }
    public void FatherAgain()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 13;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }
    public void LoveNeverComesAlone()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 14;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;

    }

    public void OnGiantFish()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 15;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;
    }

    public void TintinAndBinbin()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.IranianClick);
        page[i].gameObject.SetActive(false);
        i = 0;
        page[i].gameObject.SetActive(true);
        PageWasPlayed = true;
        ShouldEnd = true;
    }

    public void Pause()
    {
        gameObject.SetActive(false);
    }

    public void Resume()
    {
        gameObject.SetActive(true);
    }
}
