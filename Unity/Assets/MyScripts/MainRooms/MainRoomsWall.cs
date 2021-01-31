using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomsWall : MonoBehaviour
{
    // Start is called before the first frame update
    public MainRooms.MainRoomType roomType;

    public bool hit = false;
    private float hitTimeLimit = 2f;
    private float currHitTime = 0f;
    public GameObject Decor;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckVisibility();
    }

    private void OnCollisionEnter(Collision other)
    {
    }

    void OnCollisionStay(Collision other)
    {
        if (hit)
        {
            currHitTime += Time.deltaTime;
            if (currHitTime >= hitTimeLimit)
            {
                MainRooms.Rotate();
                hit = false;
                currHitTime = 0f;
            }
        }

    }

    private void OnCollisionExit(Collision other)
    {
        currHitTime = 0f;
    }

    private void CheckVisibility()
    {
        // Debug.Log(gameObject.name + " : " + Vector3.Distance(new Vector3(5f, -5f, -5f), transform.position));
        Decor.SetActive(Vector3.Distance(new Vector3(5f, 5f, -5f), transform.position) > 8.0f);
    }
}
