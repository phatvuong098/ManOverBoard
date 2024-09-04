using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotifyController : Singleton<NotifyController>
{
    [SerializeField] GameObject notifyPanel;
    [SerializeField] TMP_Text txtIndex;
    [SerializeField] TMP_Text txtLabel;

    public void ShowNotify(string index, string content)
    {
        notifyPanel.SetActive(true);
        txtIndex.text = index;
        txtLabel.text = content;
    }

    public void HideNotify()
    {
        notifyPanel.SetActive(false);
    }
}
