using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYMOVEMENT : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speedN;
    private Vector3 objectOrigin;
    private float percentageAchieved;
    private Vector3 objectDestination;

    private void Start()
    {
        objectOrigin = transform.position;
        percentageAchieved = 0;
        objectDestination = point1.position;
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(objectOrigin, objectDestination, percentageAchieved);

        if (percentageAchieved >= 1)
        {
            int rand = UnityEngine.Random.Range(1, 3);

            if (rand == 1)
            {
                objectDestination = point1.transform.position;
            }
            else if (rand == 2)
            {
                objectDestination = point2.transform.position;
            }
            
            percentageAchieved = 0;
            objectOrigin = this.transform.position;
        }
        percentageAchieved += speedN * Time.deltaTime;
    }
}
