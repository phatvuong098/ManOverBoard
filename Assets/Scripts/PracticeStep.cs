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
    public GameObject[] goSteps;
    private IStep[] steps;

    private int currentStep;

    private void Awake()
    {
        steps = new IStep[goSteps.Length];
        for (int i = 0; i < goSteps.Length; i++)
        {
            steps[i] = goSteps[i].GetComponent<IStep>();
        }
    }

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
