using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamage : MonoBehaviour
{
    public GameObject firePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFires(Transform position)
    {
        GameObject Fire = Instantiate(firePrefab, position.position, position.rotation);

    }
}
