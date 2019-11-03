using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    
    public ABoat Boat;
    public int selection = 0;
    public StatusBar status;
    public MissionBar mission;




    void Start()
    {
       


    }

    public void SetPage(int page)
    {
        if (page==0)
        {
            status.SetState(true);
            mission.SetState(false);

        }
        else if (page==1)
        {
            status.SetState(false);
            mission.SetState(true);
        }


    }

    void Update()
    {
      

    }
    
}
