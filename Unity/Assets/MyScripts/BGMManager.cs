using UnityEngine;

public static class BGMManeger
{
    public static bool sceneChanged = true;

    public static void PlayBGM(string sceneName)
    {
        if (sceneChanged)
        {
            sceneChanged = false;
            Debug.Log("load: " + "BGM/" + sceneName);
            AudioClip clip = Resources.Load<AudioClip>("BGM/" + sceneName);
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
