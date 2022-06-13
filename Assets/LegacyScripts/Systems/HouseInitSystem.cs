using Leopotam.EcsLite;
using LegacyMushrooms.Extensions.EntityToGameObject;
using UnityEngine;

namespace LegacyMushrooms
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
            
            EcsPool<RenderComponent> render = world.GetPool<RenderComponent>(); 
            EcsPool<DamageComponent> damage = world.GetPool<DamageComponent>(); 
            EcsPool<LevelComponent> level = world.GetPool<LevelComponent>(); 
            EcsPool<CapacityComponent> capacity = world.GetPool<CapacityComponent>(); 
            EcsPool<ArmorComponent> armor = world.GetPool<ArmorComponent>(); 
            EcsPool<HouseComponent> dependencies = world.GetPool<HouseComponent>(); 
            
            damage.Add(houseEntity);
            capacity.Add(houseEntity);
            level.Add(houseEntity);
            armor.Add(houseEntity);

            HouseDisplay houseDisplay = house.GetComponent<HouseDisplay>();

            ref HouseComponent houseDependencies = ref dependencies.Add(houseEntity);
            houseDependencies.Team = houseDisplay.GetTeam();
            houseDependencies.HouseType = houseDisplay.GetType();
            
            ref RenderComponent houseRender = ref render.Add(houseEntity);
            houseRender.Renderer = houseDisplay.GetPrefab();
            // houseRender.Transform = house.transform;
            
            EcsPool<UnityComponent<Transform>> transforms = world.GetPool<UnityComponent<Transform>>();
            ref var transform = ref transforms.Add(houseEntity);
            transform.Value = house.transform;

            house.transform.GetProvider().SetEntity(houseEntity);
        }
    }
}