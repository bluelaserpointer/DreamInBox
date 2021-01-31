using UnityEngine;

public static class BGMManeger
{
    public static bool sceneChanged = true;

    public static void PlayBGM(string sceneName)
    {
        if (sceneChanged)
        {
            sceneChanged = false;
            string bgmName;
            switch(sceneName)
            {
                case "MainRoom":
                    bgmName = "";
                    break;
                case "堕落":
                case "血迹":
                case "手术室":
                case "监狱":
                    bgmName = "ES_Buried in Our Lands - Enigmanic";
                    break;
                case "海岸":
                case "空间站-南":
                case "空间站-北":
                case "月球":
                    bgmName = "ES_You Give Me Air - Indigo Days";
                    break;
                case "阴暗森林":
                case "大洞穴":
                case "和风山村":
                case "地铁站":
                    bgmName = "ES_Lost Underwater - Cobby Costa";
                    break;
                case "糖果":
                case "外星迪斯科":
                    bgmName = "ES_Funky Nights - OTE";
                    break;
                case "明亮森林":
                case "悬崖":
                    bgmName = "ES_Home in the Hills - Isobel O'Connor";
                    break;
                case "塔楼":
                case "地下迷宫":
                    bgmName = "ES_Travels in Time - Experia";
                    break;
                default:
                    bgmName = "";
                    break;
            }
            if (bgmName.Length > 0)
            {
                Debug.Log("load: " + "BGM/" + bgmName);
                AudioClip clip = Resources.Load<AudioClip>("BGM/" + bgmName);
                if (clip != null)
                {
                    GameObject audioSourceObject = (GameObject)Object.Instantiate(Resources.Load("PureAudioSource"));
                    AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>();
                    audioSource.Stop();
                    audioSource.clip = clip;
                    audioSource.Play();
                }
            }
        }
    }
}
