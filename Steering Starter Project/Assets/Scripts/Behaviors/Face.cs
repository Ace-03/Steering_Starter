using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        Vector3 direction = target.transform.position - character.transform.position;

        if (direction.x == 0 && direction.z == 0)
            return 0f; 

        float targetAngle = Mathf.Atan2(-direction.x, direction.z);
        targetAngle *= Mathf.Rad2Deg;
        return targetAngle;
    }
}
