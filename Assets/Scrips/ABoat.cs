using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class  ABoat :MonoBehaviour

{

    public float Engine_RPM;
    public float engine_max_rpm;
    public IBattery Battery;
    public abstract void ThrottleUp();
    public abstract void ThrottleDown();
    public abstract void Brake();
    public abstract void Reverse();
    public abstract void RudderRight();
    public abstract void RudderLeft();
   


}
