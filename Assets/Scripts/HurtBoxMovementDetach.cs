using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HurtBoxMovementDetach : MonoBehaviour
{
    #region Variable Delcaration

    public GameObject enemyHurtbox;

    [SerializeField] private float randX;
    //[SerializeField] private float randY;
    [SerializeField] private float randZ;
    //[SerializeField] private float myRand;
    //[SerializeField] private float myRandTimer;

    Vector3 newPosition;

    System.Random myRandom = new System.Random(Seed: System.DateTime.Now.Millisecond);


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        randX = myRandom.Next(-3, 3);
        //randY = Random.Range(0f, 2f);
        randZ = myRandom.Next(-3, 3);
        //myRandTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (myRandTimer > 120)
        {
            randX = Random.Range(-2f, 2f);
            randZ = Random.Range(-2f, 2f);
            myRandTimer = 0;
            newPosition = this.transform.position + new Vector3(randX, 0, randZ);
        }
        else
        {
            myRandTimer++;
        }*/

        //myRandTimer++;

        newPosition = this.transform.position + new Vector3(randX, 0, randZ);

        enemyHurtbox.transform.position = Vector3.Lerp(enemyHurtbox.transform.position, newPosition, Time.deltaTime);
    }
}
