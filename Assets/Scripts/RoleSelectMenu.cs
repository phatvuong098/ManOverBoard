using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum Role
{
    CREW,
    CAPTAIN
}

public class RoleSelectMenu : MonoBehaviour
{
    [SerializeField] GameObject panelCaptainRole;
    [SerializeField] GameObject panelCrewRole;
    [SerializeField] GameObject panelSelectRole;

    private Role role;

    public void BTN_SelectCrewRole()
    {
        role = Role.CREW;
        panelSelectRole.SetActive(false);
        panelCrewRole.SetActive(true);
    }

    public void BTN_SelectCaptainRole()
    {
        role = Role.CAPTAIN;
        panelSelectRole.SetActive(false);
        panelCaptainRole.SetActive(true);
    }
}
