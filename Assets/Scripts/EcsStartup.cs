using UnityEngine;
using Leopotam.EcsLite;
using Mushrooms.Extensions.Ecs;

namespace Mushrooms
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world);
            _updateSystems.Add(new HouseInitSystem());
            _updateSystems.Init();

            // _fixedUpdateSystems = new EcsSystems(_world);
            // _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems.Run();
        }

        // private void FixedUpdate()
        // {
        //     _fixedUpdateSystems.Run();
        // }

        private void OnDestroy()
        {
            if (_updateSystems != null)
            {
                _updateSystems.Destroy();
                _updateSystems = null;
            }

            // if (_fixedUpdateSystems != null)
            // {
            //     _fixedUpdateSystems.Destroy();
            //     _fixedUpdateSystems = null;
            // }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}