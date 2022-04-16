using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms
{
    public class SpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsWorld world = null;
        SceneData sceneData = null;
        float defaultSpawnTimeout = 3;
        float currentSpawnTimeout = 2;

        EcsFilter houseEntities = null;
        EcsPool<RenderComponent> renderComponents = null;
        EcsPool<MushroomComponent> dependencies = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();

            houseEntities = world.Filter<RenderComponent>().Inc<CapacityComponent>().End();
            renderComponents = world.GetPool<RenderComponent>();
            dependencies = world.GetPool<MushroomComponent>();

            sceneData = systems.GetShared<SceneData>();
        }

        public void Run(EcsSystems systems)
        {
            if (currentSpawnTimeout > 0)
            {
                currentSpawnTimeout -= Time.deltaTime;
                return;
            }

            foreach (int house in houseEntities)
            {
                ref RenderComponent houseTransform = ref renderComponents.Get(house);
                // ref HouseComponent houseDependencies = ref dependencies.Get(house);

                MushroomFactory.CreateMushroom(world, sceneData.Mushroom, houseTransform.Transform.position, house);
            }
            currentSpawnTimeout = defaultSpawnTimeout;
        }
    }
}
