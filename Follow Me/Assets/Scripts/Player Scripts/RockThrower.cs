using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrower : MonoBehaviour
{
    private int numRocks;
    public Rock rockPrefab;
    public float spawnDist = 0.3f;
    public float strength = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Reset();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        numRocks = 10;
    }

    //Throw a rock at pos.
    public void ThrowRock(Vector2 pos)
    {
        if (numRocks > 0)
        {
            numRocks -=1;
            //Work out what direction the pos is from us.
            Vector2 direction = ((Vector2)(pos - (Vector2)transform.position)).normalized;
            Vector2 spawnpos = (Vector2)(transform.position) + (direction * spawnDist);
            Debug.Log("Instantiating");
            Rock r = Instantiate(rockPrefab, spawnpos, Quaternion.identity);
            Debug.Log("Throwing");
            r.Throw(direction, strength);
        }
    }
}
