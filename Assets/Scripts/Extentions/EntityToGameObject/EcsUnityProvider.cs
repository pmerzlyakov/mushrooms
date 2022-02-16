using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms.Extensions.EntityToGameObject
{
    public class EcsUnityProvider : MonoBehaviour
    {
        public ref int Entity
        {
            get
            {
                if(_entity == 0) Debug.LogWarning("Entity is not assigned!");
                return ref _entity;
            }
        }

        private int _entity;

        public void SetEntity(in int entity) => _entity = entity;
    }
}