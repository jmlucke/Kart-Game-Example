using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneController : MonoBehaviour {

    public Camera gameCamera;
    public KartController kart;
    public Text gameText;
    public float gameTimer;
    private float bestTime = 999;
    private bool finishLap;
    private int currentCheckpoint=-1;
    public GameObject checkpointContainer;
    void Start() {
        checkpointUpdate();
    }
    public void checkpointUpdate()
        {
                foreach (CheckpointController checkpoint in checkpointContainer.GetComponentsInChildren<CheckpointController>())
                    {
          checkpoint.onHitByPlayer = (int checkpointId) =>
            {
                OnReachCehckpoint(checkpointId);
            };
        }
        }
    void OnReachCehckpoint (int checkpointId)
    {
        Debug.Log(checkpointId);
        if (checkpointId== currentCheckpoint + 1)
        {
            currentCheckpoint++;
            //finishLap = false;
        }
        if(checkpointId==0 && currentCheckpoint == 2)
        {
            Debug.Log("Finished Lap");
            currentCheckpoint = 0;
            finishLap = true;
            bestTime = gameTimer < bestTime ? gameTimer : bestTime;
            gameTimer = 0;

        }

    }
    

	void Update () {
        gameCamera.transform.position = new Vector3(
            kart.transform.position.x - kart.transform.forward.x *5,
            kart.transform.position.y +3,
            kart.transform.position.z - kart.transform.forward.z * 5);
        gameCamera.transform.LookAt(kart.transform);
        gameTimer += Time.deltaTime;
        gameText.text= "Time: " + Mathf.Floor(gameTimer);
        if (finishLap == true) gameText.text += "\nBest time:" + Mathf.Floor(bestTime);
    }
}
