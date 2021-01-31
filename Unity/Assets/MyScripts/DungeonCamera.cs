using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DungeonCamera : MonoBehaviour
{
    public float followSpeed;
    public float followDistance;
    public Vector3 distanceVector;
    private CinemachineVirtualCamera virtualCamera;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        distanceVector = (player.transform.position - transform.position).normalized;
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
            Vector3 targetPosition = player.transform.position - distanceVector * followDistance;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    private void OnDestroy() {
    }
}