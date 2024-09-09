using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Step : MonoBehaviour, IStep
{
    [SerializeField] GameObject panel;

    StepController practiceStep;

    public void Active(StepController practiceStep)
    {
        NotifyController.Instance.HideNotify();
        this.practiceStep = practiceStep;
        panel.SetActive(true);
    }

    public void Done()
    {
        panel.SetActive(false);
        this.practiceStep.NextStep();
    }
}
