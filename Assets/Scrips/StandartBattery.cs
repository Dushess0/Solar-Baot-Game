using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBattery : MonoBehaviour, IBattery
{



    static float capacity=50;
    float current_capacity= capacity;
    float usage = 0;
    float max_usage=25;
    float charging_speed = 50;
    float charging_m = 0;

    public float MaxCapacity => capacity;

    public float CurrentCapacity
    {
        get => current_capacity;

        set=> current_capacity = Mathf.Clamp(value, 0, capacity);


    }


    public float Usage 
    {
        get => usage;
        set => usage = Mathf.Clamp(value, 0, max_usage);
       
       
    }

    public float MaxUsage => max_usage;

    public float ChargingSpeed => charging_m * charging_speed;

    public float Charging_multiplayer { get => charging_m; set => charging_m= Mathf.Clamp(value,0,1); }

    public float MaxChargingSpeed => charging_speed;
    void Start()
    {
        InvokeRepeating("Using", 1, 1);
    }
    public void Using()
    {
       

        this.CurrentCapacity += (charging_speed*charging_m-usage)/60;
        
       

    }
}
