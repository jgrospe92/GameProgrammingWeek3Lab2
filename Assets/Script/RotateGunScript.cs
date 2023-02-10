using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGunScript : MonoBehaviour
{
    public float minAngle = 10;
    public float maxAngle = 30;
    float gunRotation = 0;

    // Update is called once per frame
    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        gunRotation += mouseY;
        gunRotation = Mathf.Clamp(gunRotation,minAngle,maxAngle);
        transform.localEulerAngles = new Vector3(gunRotation,0,0);
       
    }
}
