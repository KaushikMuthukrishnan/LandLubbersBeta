using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeMovement : BaseShipMovement
{
    public void Start()
    {
        movementInst.Start();
    }
    public override void Move(Vector3 dir) 
    {
        RotateTransformBy(4f, dir);

        if (dir.sqrMagnitude > 0.1)
            movementInst.rb.velocity = 10f * dir.sqrMagnitude * transform.forward;  
            //TODO leave y component alone so gravity works
    }

}
