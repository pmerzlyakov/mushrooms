using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mushrooms
{
    public class SpawnSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var sceneData = systems.GetShared<SceneData> ();
            Debug.Log(sceneData.Mushroom.name.ToString());
            GameObject.Instantiate(sceneData.Mushroom, new Vector3(2.0F, 2.0F, 2.0F), Quaternion.identity);
        }
    }
}