using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShipMovement : MonoBehaviour
{
    private GameObject player;
    protected Movement movementInst;
    protected float currentVelocity;
    public void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementInst = player.GetComponent<Movement>();
        movementInst.rb.sleepThreshold = 0.001f;
    }
    protected void RotateTransformBy(float smoothTime, Vector3 dir)
    {
        float angleBetween = Vector3.SignedAngle(transform.forward, dir, transform.up);
        float rotAngle = Mathf.SmoothDampAngle(0, angleBetween, ref currentVelocity, smoothTime); // smoothTime = turning quickness
        transform.Rotate(transform.up, rotAngle);
        
        //TODO add damped accel/decel
        //aka some resistance to speed up/slow down
    }
    
    public abstract void Move(Vector3 dir);
}
