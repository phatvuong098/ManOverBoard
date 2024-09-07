using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainStepOne : MonoBehaviour, IStep
{
    [SerializeField] Outline[] outline;
    [SerializeField] string indexStep;
    [SerializeField] string helpText;

    StepController practiceStep;

    public virtual void Active(StepController practiceStep)
    {
        this.practiceStep = practiceStep;
        for (int i = 0; i < outline.Length; i++)
        {
            outline[i].enabled = true;
        }
        NotifyController.Instance.ShowNotify(indexStep, helpText);
    }

    public virtual void Done()
    {
        for (int i = 0; i < outline.Length; i++)
        {
            outline[i].enabled = false;
        }
        this.practiceStep.NextStep();
    }
}
