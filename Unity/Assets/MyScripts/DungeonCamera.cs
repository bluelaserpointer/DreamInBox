using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    public float followSpeed;
    public float followDistance;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
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
            transform.LookAt(player.transform);
            if(Vector3.Distance(player.transform.position, transform.position) > followDistance)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), followSpeed * Time.deltaTime);
            }
        }
    }

    private void OnDestroy() {
    }
}