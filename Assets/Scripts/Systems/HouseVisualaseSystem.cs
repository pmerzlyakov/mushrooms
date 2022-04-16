using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using Mushrooms.Extensions.EntityToGameObject;
using UnityEngine;

namespace Mushrooms
{
    public class HouseVisualizeSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter houseEntities = null;
        EcsPool<RenderComponent> renderComponents = null;
        SceneData sceneData = null;
        EcsPool<HouseComponent> dependencies = null; 


        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();   
            dependencies = world.GetPool<HouseComponent>();
            houseEntities = world.Filter<RenderComponent>().Inc<CapacityComponent>().End();
            renderComponents = world.GetPool<RenderComponent>();

            sceneData = systems.GetShared<SceneData>();
            foreach (int house in houseEntities) 
            {
                Debug.Log($"house id {house} HouseVisualizeSystem");      
            }
        }

        public void Run(EcsSystems systems)
        {
            // foreach (int house in houseEntities) 
            // {
            //     Debug.Log("HouseVisualizeSystem");      
            // }
            // world = systems.GetWorld();

            // var houses = GetHousesOnScene();
            // foreach (var house in houses)
            // {
            //     // InitHouse(house);
            // }
        }

        // private void InitHouse(GameObject house)
        // {

        //     EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
        //     EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
        //     EcsPool<LevelComponent> level = world.GetPool<LevelComponent>(); 
        //     EcsPool<CapacityComponent> capacity = world.GetPool<CapacityComponent>(); 
        //     EcsPool<HouseComponent> dependencies = world.GetPool<HouseComponent>(); 

        //     health.Add(houseEntity);
        //     damage.Add(houseEntity);
        //     capacity.Add(houseEntity);
        //     level.Add(houseEntity);


        //     ref HouseComponent houseDependencies = ref dependencies.Add(houseEntity);
        //     houseDependencies.Team = Teams.None;

        //     ref RenderComponent houseRender = ref render.Add(houseEntity);
        //     houseRender.Transform = house.transform;

        //     house.transform.GetProvider().SetEntity(houseEntity);
        // }
    }
}