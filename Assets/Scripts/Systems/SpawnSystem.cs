using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using Mushrooms.Extensions.EntityToGameObject;
using UnityEngine;

namespace Mushrooms
{
    public class SpawnSystem : IEcsRunSystem
    {
        EcsWorld world = null;

        float defaultSpawnTimeout = 3;
        float currentSpawnTimeout = 2;

        public void Run(EcsSystems systems)
        {
            var sceneData = systems.GetShared<SceneData>();

            world = systems.GetWorld();
            if(currentSpawnTimeout > 0)
            {
                currentSpawnTimeout -= Time.deltaTime;
                return;
            }
            InitMushroom(sceneData.Mushroom, new Vector3(5.0F, 1.0F, 2.0F));
            currentSpawnTimeout = defaultSpawnTimeout;
        }


        private void InitMushroom(Transform mushroomTransform, Vector3 position)
        {
            if (mushroomTransform == null) 
            {
                Debug.Log("mushroomTransform == null");
                return;
            }
            int mushroomEntity = world.NewEntity();
            
            EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
            EcsPool<HealthComponent> health = world.GetPool<HealthComponent>(); 
            EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
            EcsPool<MovementComponent> movement = world.GetPool<MovementComponent>(); 
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 

            health.Add(mushroomEntity);
            damage.Add(mushroomEntity);
            movement.Add(mushroomEntity);
            armor.Add(mushroomEntity);

            var mushroomGO = GameObject.Instantiate(mushroomTransform, mushroomTransform.position, Quaternion.identity);
            mushroomGO.transform.GetProvider().SetEntity(mushroomEntity);
        }
    }
}