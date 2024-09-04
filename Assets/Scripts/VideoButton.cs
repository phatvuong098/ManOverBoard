using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoButton : MonoBehaviour
{
    [SerializeField] private VideoClip clip;
    [SerializeField] private VideoPlayerController videoPlayerController;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            videoPlayerController.ShowVideo(clip);
        });
    }
}
