using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoat : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0, 15, 0);
    public Transform Player;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position=Player.transform.position + Offset;
    }
}
