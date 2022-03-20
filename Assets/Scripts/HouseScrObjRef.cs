using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScrObjRef : MonoBehaviour
{
    public House HouseScrObj = null; 
    void Start()
    {
        Debug.Log(HouseScrObj.DefaultTeam);
    }
}
