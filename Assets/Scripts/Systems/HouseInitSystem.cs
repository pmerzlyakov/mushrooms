using Leopotam.EcsLite;
using Mushrooms.Extensions.Ecs;
using UnityEngine;

namespace Mushrooms
{
    public class HouseInitSystem : IEcsInitSystem
    {
        EcsWorld world = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();

            var houses = GetHousesOnScene();
            foreach (var house in houses)
            {
                Debug.Log("houseTransform init");
                InitHouse(house);
            }
        }

        private GameObject[] GetHousesOnScene()
        {
            return GameObject.FindGameObjectsWithTag("House");
        }

        private void InitHouse(GameObject house)
        {
            if (house == null)
            {
                Debug.Log("houseTransform = null");
                return;
            }

            int houseEntity = world.NewEntity();

            EcsPool<UComponent<Transform>> transforms = world.GetPool<UComponent<Transform>>();
            ref var transform = ref transforms.Add(houseEntity);
            transform.Value = house.transform;
            house.transform.GetProvider().Entity = houseEntity;
        }
    }
}
