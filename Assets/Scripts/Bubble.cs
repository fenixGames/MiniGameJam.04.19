
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float upSpeed, shakeRange;





    private void Awake()
    {
        RandomizeShakieRange();
    }


    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * upSpeed, transform.position.z);
    }


    void MoveLeft()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + shakeRange, ))
    }


    private void RandomizeShakieRange()
    {
        shakeRange *= Random.RandomRange(-0.2f, 0.2f);
    }
}
