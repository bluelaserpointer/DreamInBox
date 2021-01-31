using UnityEngine;

[DisallowMultipleComponent]
public class Tower : MonoBehaviour
{
    public GameObject[] floors = new GameObject[5];

    public static int floor;
    private void Awake()
    {
        switch(Player.lastScene)
        {
            case "阴暗森林":
                floor = 1;
                break;
            case "监狱":
                floor = 3;
                break;
            case "MainRoom":
                floor = 4;
                break;
            default:
                floor = 0;
                break;
        }
        floors[floor].SetActive(true);
    }
    public void GoUp()
    {
        floors[floor].SetActive(false);
        floor = (floor == 4 ? 0 : (floor + 1));
        floors[floor].SetActive(true);
    }
    public void GoDown()
    {
        floors[floor].SetActive(false);
        floor = (floor == 0 ? 4 : (floor - 1));
        floors[floor].SetActive(true);
    }
}
