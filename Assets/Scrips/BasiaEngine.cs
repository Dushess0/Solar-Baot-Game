using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

 class BasiaEngine :  ABoat
{
    
    public Transform propeller;
    public Transform[] Rudders;
   

    public Transform ForwardPylon, BackPylon;

    protected Rigidbody rb;

    
    protected float throttle;
    protected int direction = 1;

    public float propellers_constant = 0.6F;
     
    public float acceleration_cst = 1.0F;
    public float drag = 0.01F;

    public float wingLift = 10;

    protected float angle;
   




    void Awake()
    {
        Engine_RPM = 0F;
        throttle = 0F;
       
        rb = GetComponent<Rigidbody>();
       



    }
    private void FixedUpdate()
    {
        float frame_rpm = Engine_RPM * Time.deltaTime;

        propeller.localRotation = Quaternion.Euler(propeller.localRotation.eulerAngles + new Vector3(0, -frame_rpm,0 ));
        rb.AddForceAtPosition(Quaternion.Euler(0, angle, 0) * propeller.up * propellers_constant * Engine_RPM, propeller.position);
            
    
        Vector3 LiftForce = new Vector3(0, Mathf.Clamp(rb.velocity.magnitude*wingLift, 60, 300), 0);
        //Debug.Log(LiftForce);
        
        rb.AddForceAtPosition(LiftForce, ForwardPylon.position);
        rb.AddForceAtPosition(LiftForce, BackPylon.position);
        
        
        
        throttle *= (1.0F - drag * 0.001F);
        Engine_RPM = throttle * engine_max_rpm * direction;

        angle = Mathf.Lerp(angle, 0.0F, 0.02F);
        for (int i = 0; i < Rudders.Length; i++)
            Rudders[i].localRotation = Quaternion.Euler(0, 0, angle);
    }

    public override void ThrottleUp()
    {
        throttle += acceleration_cst * 0.001F;
        if (throttle > 1)
            throttle = 1;
    }

    public override void ThrottleDown()
    {
        throttle -= acceleration_cst * 0.001F;
        if (throttle < 0)
            throttle = 0;
    }

    public override void Brake()
    {
        throttle *= 0.9F;
    }

    public override void Reverse()
    {
        direction *= -1;
    }

    public override void RudderRight()
    {
        angle -= 0.9F;
        angle = Mathf.Clamp(angle, -90F, 90F);
    }

    public override void RudderLeft()
    {
        angle += 0.9F;
        angle = Mathf.Clamp(angle, -90F, 90F);
    }

    void OnDrawGizmos()
    {
        Handles.Label(propeller.position, Engine_RPM.ToString());
    }
}
