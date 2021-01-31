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
        BGMManeger.PlayBGM(SceneManager.GetActiveScene().name);
        if (comeFromScenes.Contains("All") || comeFromScenes.Contains(Player.lastScene))
        {
            if (SceneManager.GetActiveScene().name.Equals("MainRoom"))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null) {
                    player.SetActive(false);
                    Destroy(player);
                }
            }   
            Instantiate(Resources.Load("PlayerVer1"), transform.position + transform.up * 1, transform.rotation);
            Instantiate(Resources.Load("Inventory"));

            Instantiate(Resources.Load("LevelChanger"));
        }
    }
    public virtual void Transport()
    {
        if(gotoScene.Equals("MainRoom") && Player.completelyUsedTransforms.Count == 6)
        {
            gotoScene = "EndScene";
        }

        LevelChanger levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponentInChildren<LevelChanger>();
        levelChanger.FadeToLevel(gotoScene);
        // SceneManager.LoadScene(gotoScene);

        BGMManeger.sceneChanged = true;
    }
}
