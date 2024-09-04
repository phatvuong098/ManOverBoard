using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStep
{
    void Active(PracticeStep practiceStep);
    void Done();
}

public class PracticeStep : MonoBehaviour
{
    public IStep[] steps;

    private int currentStep;

    public void StartFirstStep()
    {
        currentStep = 0;
        steps[currentStep].Active(this);
    }

    public void NextStep()
    {
        currentStep++;
        if (currentStep < steps.Length)
        {
            steps[currentStep].Active(this);
        }
    }

    public void Done()
    {

    }
}
