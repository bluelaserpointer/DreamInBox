using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public List<AudioClip> roomRotateAudioClips;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        animator.Play("Camera_Shake");
        audioSource.clip = roomRotateAudioClips[Random.Range(0, roomRotateAudioClips.Count)];
        audioSource.Play();
    }
}
