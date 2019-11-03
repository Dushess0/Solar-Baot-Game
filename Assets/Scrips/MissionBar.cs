using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionBar : MonoBehaviour,Ibar
{
    public RawImage player_image;
    
    public RawImage background_image;

    public RawImage BeamUI;
    public RawImage SpillUI;
    public ABoat boat;

    public List<Vector3> LocatedBeams;
    public List<Vector3> LocatedSpils;

    Text MissionHeader;

    public static float MapScale=0.4f; //1000 metres = 400 pixels

   public void AddBeam(Vector3 pos)
    {
        LocatedBeams.Add(pos);
        RawImage newBeam=Instantiate<RawImage>(BeamUI, background_image.transform);

        
        newBeam.rectTransform.anchoredPosition = player_image.rectTransform.anchoredPosition;


    }
    public void AddSpill(Vector3 pos)
    {
        LocatedSpils.Add(pos);
        RawImage newBeam = Instantiate<RawImage>(SpillUI, background_image.transform);


        newBeam.rectTransform.anchoredPosition = player_image.rectTransform.anchoredPosition;


    }
    public void SetState(bool status)
    {
        MissionHeader.gameObject.SetActive(status); 

    }

    void Start()
    {
        MissionHeader = GetComponent<Text>();


    }

    
    void Update()
    {
        player_image.rectTransform.anchoredPosition=new Vector3(boat.transform.position.x,boat.transform.position.z,0)*MapScale*-1;

        

        
    }
}
