using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyStep : MonoBehaviour, IStep
{
    [SerializeField] string indexStep;
    [SerializeField] string helpText;

    StepController practiceStep;

    public void Active(StepController practiceStep)
    {
        this.practiceStep = practiceStep;
        NotifyController.Instance.ShowNotify(indexStep, helpText);
    }

    public void Done()
    {
        this.practiceStep.NextStep();
    }
}
