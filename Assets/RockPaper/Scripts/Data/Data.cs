using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/handData", order = 1)]
public class Data : ScriptableObject
{
    public HandData[] handdata;
  
}

[Serializable]
public class HandData
{
    public string hName;
    public Sprite hIcon;
}

public enum playerType
{
    Player,
    opponent,
}
