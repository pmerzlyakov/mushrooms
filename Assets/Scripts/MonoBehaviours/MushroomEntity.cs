using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms
{
    public class MushroomEntity
    {
        public void Init(EcsSystems systems) {
            EcsWorld world = systems.GetWorld();
            
            int entity = world.NewEntity();
            
            EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
            EcsPool<HealthComponent> health = world.GetPool<HealthComponent>(); 
            EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
            EcsPool<MovementComponent> movement = world.GetPool<MovementComponent>(); 
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 

            render.Add(entity);
            health.Add(entity);
            damage.Add(entity);
            movement.Add(entity);
            armor.Add(entity);
        }
    }
}