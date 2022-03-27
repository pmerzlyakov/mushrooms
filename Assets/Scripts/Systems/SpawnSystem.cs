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
        EcsPool<DependenciesComponent> dependenciesComponents = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();

            houseEntities = world.Filter<RenderComponent>().Inc<CapacityComponent>().End();
            renderComponents = world.GetPool<RenderComponent>();
            dependenciesComponents = world.GetPool<DependenciesComponent>();

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
                ref DependenciesComponent houseDependencies = ref dependenciesComponents.Get(house);


                // MushroomFactory.CreateMushroom(world, sceneData.Mushroom, houseTransform.Transform.position, house);
                currentSpawnTimeout = defaultSpawnTimeout;
            }
        }
    }
}
