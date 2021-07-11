using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform playerVFX, camAnch, cam;
    public Rigidbody rb;
    private float camY;
    private BaseShipMovement VFXReference;
    public void Start()
    {
        playerVFX = transform.GetChild(0); 
        VFXReference = playerVFX.GetComponent<BaseShipMovement>();
    }
    private void Update() 
    {
        Look();
        VFXReference.Move(GetMoveDirection());
    }
    private void Look()
    {
        if (Time.timeScale > 0f)
        {
            camAnch.Rotate(0, Input.GetAxis("Mouse X"), 0);
            camY += -Input.GetAxis("Mouse Y");
            camY = Mathf.Clamp(camY, 20, 45);
            cam.localRotation = Quaternion.Euler(camY, 0, 0);
        }
    } 
    public Vector3 GetMoveDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        if (dir.sqrMagnitude >= 1)
            dir = dir.normalized;
        dir = Quaternion.Euler(0, cam.eulerAngles.y, 0) * dir;

        return dir;
    }


}
