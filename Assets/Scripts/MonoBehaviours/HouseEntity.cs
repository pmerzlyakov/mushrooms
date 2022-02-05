using Leopotam.EcsLite;

namespace Mushrooms
{
    public class HouseEntity
    {
        public void Init(EcsSystems systems) {
            EcsWorld world = systems.GetWorld();
            
            int entity = world.NewEntity();
            
            EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
            EcsPool<HealthComponent> health = world.GetPool<HealthComponent>(); 
            EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
            EcsPool<LevelComponent> level = world.GetPool<LevelComponent>(); 
            EcsPool<CapacityComponent> capacity = world.GetPool<CapacityComponent>(); 
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 

            render.Add(entity);
            health.Add(entity);
            damage.Add(entity);
            capacity.Add(entity);
            level.Add(entity);
            armor.Add(entity);
        }
    }
}