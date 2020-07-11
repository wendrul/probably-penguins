using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ship")
        {
            hitInfo.SendMessage("SpawnFires", gameObject.transform);
            Destroy(gameObject);

        }
        else if(hitInfo.name == "Robot")
        {
            hitInfo.SendMessage("DetractPoints", 15);
            Destroy(gameObject);


        }
    }
}
