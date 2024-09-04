using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ROLE
{
    CAPTAIN,
    CREW
}

public class GameData : Singleton<GameData>
{
    private ROLE currentRole;
    public ROLE CurrentRole { get => currentRole; set => currentRole = value; }



}
