using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{


    [SerializeField]
    private float startSpeed, endSpeed;

    [SerializeField]
    private GameObject spawnRange;

    [SerializeField]
    private GameObject bubblePrefab;

    [SerializeField]
    private float spawnFrequency, smallSize, bigSize;


    private float minimumY, minimumX, maximumY, maximumX;


    private void Awake()
    {
        SpriteRenderer rend = spawnRange.GetComponent<SpriteRenderer>();
        minimumX = rend.bounds.min.x;
        minimumY = rend.bounds.min.y;
        maximumX = rend.bounds.max.x;
        maximumY = rend.bounds.max.y;

    }
     

    void Update()
    {     
        if(spawnFrequency > Random.RandomRange(0,100))
        Spawnbubble();
    }


    void Spawnbubble()
    {
        Vector2 spawnPosition = new Vector2(Random.RandomRange(minimumX, maximumX), Random.RandomRange(minimumY, maximumY));
        Bubble newbubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity).GetComponent<Bubble>();
        newbubble.SetSizeAndSpeed(Random.Range(smallSize, bigSize));


    }
}
