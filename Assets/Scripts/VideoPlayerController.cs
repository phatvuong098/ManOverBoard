using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Image playBTN;
    [SerializeField] private Image duration;

    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;

    [SerializeField] private GameObject panel;

    public void BTN_Play()
    {
        if (videoPlayer.isPlaying)
        {
            playBTN.sprite = playSprite;
            videoPlayer.Pause();
        }
        else
        {
            playBTN.sprite = pauseSprite;
            videoPlayer.Play();
        }
    }

    public void BTN_Reload()
    {
        videoPlayer.Stop();
        videoPlayer.Play();
        playBTN.sprite = pauseSprite;
    }

    private void Update()
    {
        if(videoPlayer.isPlaying)
        {
            duration.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }

    public void BTN_Exit()
    {
        videoPlayer.Stop();
        panel.SetActive(false);
    }

    public void ShowVideo(VideoClip clip)
    {
        panel.SetActive(true);
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }
}
