using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private float maxTimeSeconds;


    private float counter;


    private void Awake()
    {
        counter = maxTimeSeconds;   
    }



    private void Update()
    {
        counter -= Time.deltaTime;
    }


    public float GetTimeLeftInPercent()
    {
        return (counter/maxTimeSeconds);
    }


}
