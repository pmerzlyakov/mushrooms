using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mushrooms;

[CreateAssetMenu(fileName = "New House", menuName = "ScriptableObjects/House")]
public class House : ScriptableObject 
{
    //TODO: separate
    [field: SerializeField] public Teams DefaultTeam { get; private set; }
    [field: SerializeField] public HouseTypes Type { get; private set; }
    [field: SerializeField] public Renderer Prefab { get; private set; }


    //how much NoneTeam players you need to kill to get this house
    // [field: SerializeField] public int StartPriceInMushrooms { get; private set; } 
    // [field: SerializeField] public int DefaultLevel { get; private set; }
    // [field: SerializeField] public int Capacity { get; private set; }
}