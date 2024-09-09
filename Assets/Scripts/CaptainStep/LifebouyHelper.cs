using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebouyHelper : MonoBehaviour
{
    [SerializeField] Transform savePeopleAnchor;
    [SerializeField] CaptainStepOne step;

    Rigidbody _rigidbody;
    bool isWasTrigger;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ResetTrigger()
    {
        isWasTrigger = false;
        _rigidbody.isKinematic = false;
    }

    private void Update()
    {
        if (!isWasTrigger && transform.position.y < -15)
        {
            transform.position = savePeopleAnchor.position;
            transform.rotation = savePeopleAnchor.rotation;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            step.Done();
            isWasTrigger = true;
        }
    }
}
