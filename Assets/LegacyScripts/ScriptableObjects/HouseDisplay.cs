using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegacyMushrooms
{
   public class HouseDisplay : MonoBehaviour
   {
      public House house;

      public Teams GetTeam()
      {
         return house.DefaultTeam;
      }
      
      public Renderer GetPrefab()
      {
         return house.Prefab;
      }
      
      public HouseTypes GetType()
      {
         return house.Type;
      }
   }
}