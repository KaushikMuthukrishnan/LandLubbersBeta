using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidMovement : BaseShipMovement
{
    public void Start()
    {
        movementInst.Start();
    }
    public override void Move(Vector3 dir) 
    {
        RotateTransformBy(2f, dir);

        if (dir.sqrMagnitude > 0.1)
            movementInst.rb.velocity = 14f * dir.sqrMagnitude * transform.forward;    
    }

}
