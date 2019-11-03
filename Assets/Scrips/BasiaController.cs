﻿using UnityEngine;
using System.Collections;

public class BasiaController : MonoBehaviour
{
    public ABoat engine;
    bool forward = true;
    public IBattery Battery;
    public float passive_charging = 0.25f;

    private void Start()
    {
        Battery = GetComponent<StandartBattery>();
        Battery.Charging_multiplayer = passive_charging;

    }
    void ControlBoat()
    {
        
        if (Input.GetKey(KeyCode.D))
            engine.RudderLeft();
        if (Input.GetKey(KeyCode.Q))
            engine.RudderRight();

        if (forward)
        {
            if (Input.GetKey(KeyCode.Z))
                engine.ThrottleUp();
            else if (Input.GetKey(KeyCode.S))
            {
                engine.ThrottleDown();
                engine.Brake();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
                engine.ThrottleUp();
            else if (Input.GetKey(KeyCode.Z))
            {
                engine.ThrottleDown();
                engine.Brake();
            }
        }

        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S))
            engine.ThrottleDown();

        if (engine.Engine_RPM == 0 && Input.GetKeyDown(KeyCode.S) && forward)
        {
            forward = false;
            engine.Reverse();
        }
        else if (engine.Engine_RPM == 0 && Input.GetKeyDown(KeyCode.Z) && !forward)
        {
            forward = true;
            engine.Reverse();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            Beam beam = other.gameObject.GetComponent<Beam>();
            Battery.Charging_multiplayer = beam.charge_m;
            Debug.Log("charging");


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
           
            Battery.Charging_multiplayer = passive_charging;
            Debug.Log("discharging");


        }
    }
    void Update()
    {
        if (Battery.CurrentCapacity!=0)
          ControlBoat();
        Debug.Log(Battery.Charging_multiplayer);
        Battery.Usage = Battery.MaxUsage* (engine.Engine_RPM / engine.engine_max_rpm);
       


      
    }

}