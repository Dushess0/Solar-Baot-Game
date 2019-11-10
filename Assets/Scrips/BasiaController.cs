using UnityEngine;
using System.Collections;

public class BasiaController : MonoBehaviour
{
    public ABoat engine;
    bool forward = true;
    public IBattery Battery;
    public float passive_charging = 0.25f;
    public InfoPanel infoPanel;

    private void Start()
    {
        Battery = GetComponent<StandartBattery>();
        Battery.Charging_multiplayer = passive_charging;
        infoPanel.SetPage(0);

    }
    void ControlBoat()
    {
        
        if (Input.GetKey(KeyCode.A))
            engine.RudderLeft();
        if (Input.GetKey(KeyCode.D))
            engine.RudderRight();

        if (forward)
        {
            if (Input.GetKey(KeyCode.W))
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
            else if (Input.GetKey(KeyCode.W))
            {
                engine.ThrottleDown();
                engine.Brake();
            }
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            engine.ThrottleDown();

        if (engine.Engine_RPM == 0 && Input.GetKeyDown(KeyCode.S) && forward)
        {
            forward = false;
            engine.Reverse();
        }
        else if (engine.Engine_RPM == 0 && Input.GetKeyDown(KeyCode.W) && !forward)
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
            if (!beam.located)
            {
                beam.located = true;
                infoPanel.mission.AddBeam(beam.transform.position);
            }
           
        }
        else if (other.gameObject.tag=="Oil")
        {
            OilProperties oil = other.gameObject.GetComponent<OilProperties>();
            engine.engine_max_rpm /= OilProperties.slowdown;
            if(!oil.located)
            {
                oil.located = true;
                infoPanel.mission.AddSpill(oil.transform.position);
                Debug.Log("Enter");
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
           
            Battery.Charging_multiplayer = passive_charging;
           
        }
        else if (other.gameObject.tag=="Oil")
        {
            engine.engine_max_rpm *= OilProperties.slowdown;
            Debug.Log("Exit");
        }
    }
    void Update()
    {
        if (Battery.CurrentCapacity!=0)
          ControlBoat();
       
        Battery.Usage = Battery.MaxUsage* (engine.Engine_RPM / engine.engine_max_rpm);


        if (Input.GetKey(KeyCode.M))
            infoPanel.SetPage(1);

        if (Input.GetKey(KeyCode.I))
            infoPanel.SetPage(0);

       




    }

}
