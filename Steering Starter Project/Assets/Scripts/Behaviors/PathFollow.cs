using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : Seek
{
    //public Kinematic character;
    

    public GameObject[] targetPath;

    int currentTarget;

    float targetRadius = 0.5f;

    float maxAcceleration = 100f;

    public override SteeringOutput getSteering()
    {
        /*
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPosition = getTargetPosition();
        if (targetPosition == Vector3.positiveInfinity)
        {
            return null;
        }
        */

        if (target == null)
        {
            int currentTarget = 0;
            float distanceToNearest = float.PositiveInfinity;
            for (int i = 0; i < targetPath.Length; i++)
            {
                GameObject candidate = targetPath[i];
                Vector3 vectorToCandidate = candidate.transform.position - character.transform.position;
                float distanceToCandidate = vectorToCandidate.magnitude;
                if (distanceToCandidate < distanceToNearest)
                {
                    currentTarget = i;
                    distanceToNearest = distanceToCandidate;
                }
            }
            target = targetPath[currentTarget];
        }


        float distance = (target.transform.position - character.transform.position).magnitude;
        if (distance < targetRadius)
        {
            currentTarget++;
            if (currentTarget > targetPath.Length - 1)
            {
                currentTarget = 0;
            }
            target = targetPath[currentTarget];
        }

        return base.getSteering();

        //result.linear = targetPosition - character.transform.position;
        

            //result.linear = target.transform.position - character.transform.position;
            
        
        // give full acceleration along this direction
        /*
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
        */
    }
}
