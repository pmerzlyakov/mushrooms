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
        
        EcsFilter houseEntities = null;
        EcsPool<Mushrooms.RenderComponent> renderEntities = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();   

            houseEntities = world.Filter<RenderComponent>().Inc<CapacityComponent>().End();
            renderEntities = world.GetPool<RenderComponent>();

            sceneData = systems.GetShared<SceneData>();
        }

        public void Run(EcsSystems systems)
        {
            if(currentSpawnTimeout > 0)
            {
                currentSpawnTimeout -= Time.deltaTime;
                return;
            }

            foreach (int house in houseEntities) 
            {
                ref RenderComponent houseTransform = ref renderEntities.Get(house);
                
                Debug.Log($"house id {house}");
                Debug.Log(houseTransform.Transform.position);

                MushroomFactory.CreateMushroom(world, sceneData.Mushroom, houseTransform.Transform.position, house);
                currentSpawnTimeout = defaultSpawnTimeout;
            }
        }
    }
}