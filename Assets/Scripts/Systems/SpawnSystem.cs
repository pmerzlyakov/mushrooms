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

        //TODO:refactor!
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
                InitMushroom(sceneData.Mushroom, housesTransform.position);
                currentSpawnTimeout = defaultSpawnTimeout;
            }
        }


        private void InitMushroom(Transform mushroomTransform, Vector3 position)
        {
            if (mushroomTransform == null) 
            {
                Debug.Log("mushroomTransform = null");
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

            ref RenderComponent mushroomRender = ref render.Add(mushroomEntity);
            mushroomRender.Transform = mushroomTransform;

            var mushroomGO = GameObject.Instantiate(mushroomTransform, position, Quaternion.identity);
            mushroomGO.transform.GetProvider().SetEntity(mushroomEntity);
        }
    }
}