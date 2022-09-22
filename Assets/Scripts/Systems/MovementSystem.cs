using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var mvmts = world.GetPool<MovementComponent>();
            var rbodies = world.GetPool<UComponent<Rigidbody>>();

            var filter = world.Filter<MovementComponent>().Inc<UComponent<Rigidbody>>().End();

            foreach (int ent in filter)
            {
                ref var mvmt = ref mvmts.Get(ent);
                ref var rbody = ref rbodies.Get(ent);

                Rigidbody rb = rbody.Value;
                var pos = Vector3.MoveTowards(rb.position, mvmt.Target, mvmt.Speed * Time.fixedDeltaTime);
                rb.MovePosition(pos);
            }
        }
    }
}
