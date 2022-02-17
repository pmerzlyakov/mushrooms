using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using Mushrooms.Extensions.EntityToGameObject;
using UnityEngine;

namespace Mushrooms
{
    public class HouseInitSystem : IEcsInitSystem
    {
        EcsWorld world = null;


        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();

            var houses = GetHousesOnScene();
            foreach (var house in houses)
            {
                InitHouse(house);
            }
        }

        private GameObject[] GetHousesOnScene()
        {
            return GameObject.FindGameObjectsWithTag("House");
        }

        private void InitHouse(GameObject house)
        {
            if (house == null) 
            {
                Debug.Log("houseTransform = null");
                return;
            }
            
            int houseEntity = world.NewEntity();
            
            EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
            EcsPool<HealthComponent> health = world.GetPool<HealthComponent>(); 
            EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
            EcsPool<LevelComponent> level = world.GetPool<LevelComponent>(); 
            EcsPool<CapacityComponent> capacity = world.GetPool<CapacityComponent>(); 
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 

            health.Add(houseEntity);
            damage.Add(houseEntity);
            capacity.Add(houseEntity);
            level.Add(houseEntity);
            armor.Add(houseEntity);

            ref RenderComponent houseRender = ref render.Add(houseEntity);
            houseRender.Transform = house.transform;

            house.transform.GetProvider().SetEntity(houseEntity);
        }
    }
}