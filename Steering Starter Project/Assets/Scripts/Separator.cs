using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : Kinematic
{
    Separation myMoveType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;
    public Kinematic[] myTargets;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = myTargets;
        //myMoveType.flee = flee;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
    }
}
