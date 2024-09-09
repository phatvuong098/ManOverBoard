using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public Vector3 originalPosition;
    public Quaternion originalRotation;
}

public interface IStep
{
    void Active(StepController practiceStep);
    void Done();
}

public class StepController : MonoBehaviour
{
    public GameObject[] Go_Steps;
    [SerializeField] private Transform practiveDestination;
    [SerializeField] private Transform originalDestination;

    [SerializeField] private Transform[] resetTransforms;

    private IStep[] steps;

    private int currentStep;
    private SaveData[] saveDatas;

    private void Start()
    {
        saveDatas = new SaveData[resetTransforms.Length];
        for (int i = 0; i < resetTransforms.Length; i++)
        {
            saveDatas[i] = new SaveData();
            saveDatas[i].originalPosition = resetTransforms[i].position;
            saveDatas[i].originalRotation = resetTransforms[i].rotation;
        }

        steps = new IStep[Go_Steps.Length];
        for (int i = 0; i < Go_Steps.Length; i++)
        {
            steps[i] = Go_Steps[i].GetComponent<IStep>();
        }
    }

    public void StartFirstStep()
    {
        for (int i = 0; i < resetTransforms.Length; i++)
        {
            resetTransforms[i].position = saveDatas[i].originalPosition;
            resetTransforms[i].rotation = saveDatas[i].originalRotation;
        }

        currentStep = 0;
        steps[currentStep].Active(this);

        GetComponent<TeleportUltilities>()?.TeleportPlayerToDestination(practiveDestination);
    }

    public void NextStep()
    {
        currentStep++;
        if (currentStep < steps.Length)
        {
            steps[currentStep].Active(this);
        }
        else
        {
            Done();
        }
    }

    public void Done()
    {
        GetComponent<TeleportUltilities>()?.TeleportPlayerToDestination(originalDestination);
    }
}
