using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2 : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (Random.Range(1, 3) == 1)
        {
            animator.SetBool("purple", true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!GameState.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ship")
        {
            AudioManager.Instance.PlaySFX(GameAssets.i.SpaceCrashSFX);
            hitInfo.SendMessage("SpawnFires", gameObject.transform);
            Destroy(gameObject);

        }
        else if(hitInfo.name == "Robot")
        {
            AudioManager.Instance.PlaySFX(GameAssets.i.SpaceCrashSFX);
            hitInfo.SendMessage("DetractPoints", 15);
            Destroy(gameObject);
        }
    }
}
