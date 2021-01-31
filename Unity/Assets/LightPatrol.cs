using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPatrol : MonoBehaviour
{
    public float patrolSpeed;
    public float lerpOffset;
    public Transform patrolPositions;
    public float patrolCoolDownTime = 2f;
    private float currCoolDownTime = 0f;
    private bool patrolCoolDown = false;
    List<Vector3> patrolList;
    int currPosIdx = 0;
    // Start is called before the first frame update
    void Start()
    {
        patrolList = new List<Vector3>();

        int childCount = patrolPositions.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform child = patrolPositions.GetChild(i);

            patrolList.Add(child.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(patrolCoolDownTime > 0f && patrolCoolDown == true)
        {
            currCoolDownTime += Time.deltaTime;
            if(currCoolDownTime >= patrolCoolDownTime)
            {
                patrolCoolDown = false;
                currCoolDownTime = 0f;
            }

            return;
        }

        transform.position = Vector3.Lerp(transform.position, patrolList[currPosIdx], patrolSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, patrolList[currPosIdx]) < lerpOffset)
        {
            currPosIdx++;
            if(currPosIdx == patrolList.Count)
                currPosIdx = 0;
            patrolCoolDown = true;
        }
    }
}
