using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using Mushrooms.Extensions.EntityToGameObject;
using UnityEngine;

namespace Mushrooms
{
    public class SpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsWorld world = null;
        SceneData sceneData = null;
        float defaultSpawnTimeout = 3;
        float currentSpawnTimeout = 2;
        List<Transform> housesTransforms = new List<Transform>();


        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();   

            var housesEntities = world.Filter<RenderComponent>().Inc<CapacityComponent>().End();
            var housesEntitiesss = world.GetPool<RenderComponent>();

            foreach (int house in housesEntities) 
            {
                ref RenderComponent houseTransform = ref housesEntitiesss.Get(house);
                housesTransforms.Add(houseTransform.Transform);
            }
            sceneData = systems.GetShared<SceneData>();
        }

        public void Run(EcsSystems systems)
        {
            if(currentSpawnTimeout > 0)
            {
                currentSpawnTimeout -= Time.deltaTime;
                return;
            }
            foreach(var housesTransform in housesTransforms)
            {
                Debug.Log(housesTransform.position);
                MushroomFactory.CreateMushroom(world, sceneData.Mushroom, housesTransform.position);
                currentSpawnTimeout = defaultSpawnTimeout;
            }
        }
    }
}