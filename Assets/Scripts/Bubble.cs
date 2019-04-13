
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float upSpeed, shakeRange;


    private float timeSinceSpawn;





    


  

    public void SetSizeAndSpeed(float size)
    {
        transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y * size, 1);
        upSpeed *= size;
        RandomizeShakieRange();
    }


    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * upSpeed, transform.position.z);
        transform.position = transform.position + new Vector3((Mathf.Sin(timeSinceSpawn) * shakeRange), 0.0f, 0.0f);

        if(timeSinceSpawn  > 100)
            Destroy(this.gameObject);
    }


    void MoveLeft()
    {
      //  transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + shakeRange, ))
    }


    private void RandomizeShakieRange()
    {
        shakeRange *= Random.RandomRange(0.5f, 1.5f);
    }
}
