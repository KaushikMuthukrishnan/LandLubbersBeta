using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPlusMovement : BaseShipMovement
{
    public void Start()
    {
        movementInst.Start();
    }
    public override void Move(Vector3 dir) 
    {
        RotateTransformBy(2f, dir);

        if (dir.sqrMagnitude > 0.1)
            movementInst.rb.velocity = 12f * dir.sqrMagnitude * transform.forward;    
    }


}
