using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms.Extensions.EntityToGameObject
{
    public abstract class EcsUnityNotifierBase : MonoBehaviour
    {
        protected ref int Entity => ref Provider.Entity;

        private EcsUnityProvider Provider
        {
            get
            {
                if (_provider != null) return _provider;
                if (!TryGetComponent(out _provider)) throw new Exception();
                return _provider;
            }
        }

        private EcsUnityProvider _provider;
    }
}