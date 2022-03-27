using Leopotam.EcsLite;
using Mushrooms.Extensions.EntityToGameObject;
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
            EcsPool<DependenciesComponent> dependencies = world.GetPool<DependenciesComponent>(); 
            
            damage.Add(houseEntity);
            capacity.Add(houseEntity);
            level.Add(houseEntity);
            armor.Add(houseEntity);

            HouseDisplay houseDisplay = house.GetComponent<HouseDisplay>();
            var houseName = houseDisplay.GetTeam();
            var houseTypeName = houseDisplay.GetType();
            // var houseName = house.transform.name.Split(' ');
            // var teamName = houseName[0];
            // var houseTypeName = houseName[1];

            ref DependenciesComponent houseDependencies = ref dependencies.Add(houseEntity);
            houseDependencies.Team = houseName; 
            houseDependencies.HouseType = houseTypeName;
            Debug.Log($"houseDependencies.Team {houseDependencies.Team}");

            ref RenderComponent houseRender = ref render.Add(houseEntity);
            houseRender.Transform = house.transform;

            EcsPool<UnityComponent<Transform>> transforms = world.GetPool<UnityComponent<Transform>>();
            ref var transform = ref transforms.Add(houseEntity);
            transform.Value = house.transform;

            house.transform.GetProvider().SetEntity(houseEntity);
        }
    }
}