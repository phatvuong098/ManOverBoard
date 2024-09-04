using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellcomeStep : MonoBehaviour, IStep
{
    [SerializeField] GameObject panel;

    PracticeStep practiceStep;

    public void Active(PracticeStep practiceStep)
    {
        this.practiceStep = practiceStep;
        panel.SetActive(true);
    }

    public void Done()
    {
        panel.SetActive(false);
        this.practiceStep.NextStep();
    }
}
