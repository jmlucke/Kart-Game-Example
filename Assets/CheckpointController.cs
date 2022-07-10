using System.Collections;
using UnityEngine;
using System;

public class CheckpointController : MonoBehaviour {

    public int checkpointId;
    public Action<int> onHitByPlayer;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider c)
    {
        if(c.GetComponent<KartController>() != null)
        {
            onHitByPlayer(checkpointId);
        }
    }

}
