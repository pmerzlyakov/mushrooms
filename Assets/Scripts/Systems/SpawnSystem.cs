using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mushrooms
{
    public class SpawnSystem : IEcsInitSystem
    {
        EcsWorld world = null;
        public void Init(EcsSystems systems)
        {
            var sceneData = systems.GetShared<SceneData>();

            world = systems.GetWorld();
            InitMushroom(sceneData.Mushroom, new Vector3(2.0F, 2.0F, 2.0F));
            InitMushroom(sceneData.Mushroom, new Vector3(5.0F, 2.0F, 2.0F));
        }


        private void InitMushroom(Transform mushroomTransform, Vector3 position)
        {
            if (mushroomTransform == null) 
            {
                Debug.Log("mushroomTransform == null");
                return;
            }
            int entity = world.NewEntity();
            
            EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
            EcsPool<HealthComponent> health = world.GetPool<HealthComponent>(); 
            EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
            EcsPool<MovementComponent> movement = world.GetPool<MovementComponent>(); 
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 

            ref var a = ref render.Add(entity);
            a.Transform = mushroomTransform;
            health.Add(entity);
            damage.Add(entity);
            movement.Add(entity);
            armor.Add(entity);

            GameObject.Instantiate(a.Transform, position, Quaternion.identity);
        }
    }
}