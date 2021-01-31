using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class TransportSpot : MonoBehaviour
{
    [Header("来自<<<")]
    public List<string> comeFromScenes;

    [Header("去往>>>")]
    public string gotoScene;
    public bool needInteraction;

    void Start()
    {
        if (comeFromScenes.Contains(Player.lastScene))
        {
            if(SceneManager.GetActiveScene().name.Equals("MainRoom"))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                    Destroy(player);
            }   
            Instantiate(Resources.Load("PlayerVer1"), transform.position + transform.up * 1, transform.rotation);
        }
    }
    public virtual void Transport()
    {
        SceneManager.LoadScene(gotoScene);
    }
}
