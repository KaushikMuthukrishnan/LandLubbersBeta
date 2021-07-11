using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMovement : BaseShipMovement
{ 
    public void Start()
    {
        movementInst.Start();
    }
    public override void Move(Vector3 dir) 
    {
        RotateTransformBy(1f, dir);

        if (dir.sqrMagnitude > 0.1)
            movementInst.rb.velocity = 20f * dir.sqrMagnitude * transform.forward;
    }

}
