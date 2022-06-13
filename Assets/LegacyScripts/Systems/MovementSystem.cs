using Leopotam.EcsLite;
using UnityEngine;

namespace LegacyMushrooms
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var mask = world.Filter<MovementComponent>();
            mask.Inc<UnityComponent<Rigidbody>>();

            EcsFilter filter = mask.End();

            var movements = world.GetPool<MovementComponent>();
            var bodies = world.GetPool<UnityComponent<Rigidbody>>();

            foreach (int entity in filter)
            {
                ref var movement = ref movements.Get(entity);
                ref var body = ref bodies.Get(entity);

                Rigidbody rb = body.Value;
                var pos = Vector3.MoveTowards(rb.position, movement.Target, movement.Speed * Time.fixedDeltaTime);

                rb.MovePosition(pos);
            }
        }
    }
}