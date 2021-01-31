using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PrisonCamera : MonoBehaviour
{
    public GameObject[] detections;
    public CinemachineVirtualCamera currVirtualCamera;
    public CinemachineVirtualCamera groundCamera;
    public CinemachineVirtualCamera floatCamera;
    public Transform groundDetection;
    private GameObject player;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Vector3 trans = player.transform.position;
            float zCoord = trans.z;
            
            if(zCoord < groundDetection.position.z)
            {
                SetCurrent(groundCamera);
                Vector3 groundTrans = groundCamera.transform.position;
                groundCamera.transform.position = new Vector3(groundTrans.x, groundTrans.y, trans.z);
            }else{
                SetCurrent(floatCamera);
            }
        }
    }

    void SetCurrent(CinemachineVirtualCamera setVirtualCamera)
    {
        if(currVirtualCamera != setVirtualCamera)
        {
            Debug.Log(setVirtualCamera.gameObject.name);
            if(currVirtualCamera != null)
                currVirtualCamera.Priority = 10;

            currVirtualCamera = setVirtualCamera;
            currVirtualCamera.Priority = 15;
        }
    }
}
