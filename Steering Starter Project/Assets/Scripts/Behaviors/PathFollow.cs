using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : Seek
{
    public GameObject[] targetPath;

    int currentTarget;

    float targetRadius = 0.5f;

    public override SteeringOutput getSteering()
    {
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
    }
}
