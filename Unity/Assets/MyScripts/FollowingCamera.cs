using UnityEngine;

[DisallowMultipleComponent]
public class FollowingCamera : MonoBehaviour
{
    public GameObject lookedAt;

    private Vector3 distance;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = lookedAt.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = player.transform.position - distance;
        else
            player = GameObject.FindGameObjectWithTag("Player");
    }
}
