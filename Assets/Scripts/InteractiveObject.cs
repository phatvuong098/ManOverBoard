using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] Outline outline;
    [SerializeField] GameObject notiUI;

    private void Awake()
    {
        Disactive();
    }

    public void Active()
    {
        outline.enabled = true;
        notiUI.SetActive(true);
    }

    public void Disactive()
    {
        outline.enabled = false;
        notiUI.SetActive(false);
    }
}
