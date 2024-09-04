using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneStep : CaptainStepOne, IStep
{
    [SerializeField] GameObject panel;

    public override void Active(PracticeStep practiceStep)
    {
        base.Active(practiceStep);

        
    }

    public void OnGrabbed()
    {
        panel.SetActive(true);
    }

    public override void Done()
    {
        base.Done();
        panel.SetActive(false);
    }
}
