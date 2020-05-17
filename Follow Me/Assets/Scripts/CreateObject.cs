using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
    }
}
