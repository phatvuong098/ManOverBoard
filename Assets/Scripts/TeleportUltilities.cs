using HurricaneVR.Framework.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUltilities : MonoBehaviour
{
    [SerializeField] HVRTeleporter HVRTeleporter;

    public void TeleportPlayerToDestination(Transform destination)
    {
        HVRTeleporter.Teleport(destination.position, destination.forward, true);
    }
}
