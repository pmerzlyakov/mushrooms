using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegacyMushrooms.Extensions.EntityToGameObject;

namespace LegacyMushrooms
{
    public static class MushroomFactory
    {

        public static void CreateMushroom(EcsWorld world, Transform mushroomTransform, Vector3 position, int houseID)
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
            EcsPool<MushroomComponent> dependency = world.GetPool<MushroomComponent>(); 
            
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 

            health.Add(mushroomEntity);
            damage.Add(mushroomEntity);
            movement.Add(mushroomEntity);
            armor.Add(mushroomEntity);

            ref RenderComponent mushroomRender = ref render.Add(mushroomEntity);
            mushroomRender.Transform = mushroomTransform;
            
            ref MushroomComponent mushroomDependencies = ref dependency.Add(mushroomEntity);
            mushroomDependencies.House = houseID;

            var mushroomGO = GameObject.Instantiate(mushroomTransform, position, Quaternion.identity);
            mushroomGO.transform.GetProvider().SetEntity(mushroomEntity);
        }
    }
}