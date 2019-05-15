using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehaviorScript : MonoBehaviour
{
    float myRandTimer;
    float randX;
    float randZ;
    System.Random myRandom = new System.Random(Seed: System.DateTime.Now.Millisecond);
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myRandTimer > 120)
        {
            randX = myRandom.Next(-3, 3);
            //randY = Random.Range(0f, 2f);
            randZ = myRandom.Next(-3, 3);
            myRandTimer = 0;
        }
        else
        {
            myRandTimer++;
        }
        newPosition = this.transform.position + new Vector3(randX, 0, randZ);
        transform.position = Vector3.Lerp(this.transform.position, newPosition, Time.deltaTime);
    }
}
