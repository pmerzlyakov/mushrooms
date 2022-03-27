using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms
{
    public class StartMovementSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            EcsFilter movementsFilter = world.Filter<StartMovementRequest>().End();
            EcsFilter mushroomsFilter = world.Filter<DependenciesComponent>().End();

            var movementReqs = world.GetPool<StartMovementRequest>();
            var deps = world.GetPool<DependenciesComponent>();
            var movements = world.GetPool<MovementComponent>();
            var transforms = world.GetPool<UnityComponent<Transform>>();

            foreach (int houseEntity in movementsFilter)
            {
                ref var req = ref movementReqs.Get(houseEntity);
                ref var target = ref transforms.Get(req.EnemyHouseEntity);

                foreach (int mushroomEntity in mushroomsFilter)
                {
                    ref var dep = ref deps.Get(mushroomEntity);

                    if (dep.House != houseEntity) continue;

                    if (movements.Has(mushroomEntity)) continue;

                    ref var move = ref movements.Add(mushroomEntity);
                    move.Speed = 2f;
                    move.Target = target.Value.position;
                }
            }

            foreach (int houseEntity in movementsFilter)
            {
                Debug.Log("delete request");
                movementReqs.Del(houseEntity);
            }
        }
    }
}
