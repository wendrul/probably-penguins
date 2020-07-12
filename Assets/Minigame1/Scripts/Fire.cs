using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float t;
    private GameObject p;
    private Player player;
    private bool isFixing;
    private Collider2D playerCollider;

    private float e;
    // Start is called before the first frame update
    void Start()
    {
        e = 0;
        p = GameObject.Find("Robot");
        player = p.GetComponent<Player>();
        t = 0;
        isFixing = false;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 6)
        {
            player.DetractPoints(5);
            Destroy(gameObject);
        }
        if (isFixing)
        {
            e += Time.deltaTime;
            FixFire();

        }
        if (!GameState.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void FixFire()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.BlowtorchSFX);
        playerCollider.SendMessage("AddPoints");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robot")
        {
            isFixing = true;
            playerCollider = hitInfo;

        }
    }

    private void OnTriggerExit2D(Collider2D hitinfo) 
    {
        if(hitinfo.name == "Robot")
        {
            isFixing = false;
            e = 0;
        }
        
    }
}
