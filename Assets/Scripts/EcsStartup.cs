using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixUpdateSystems;

        // TODO: replace with real shared data
        private object _sharedData = null;

        private void Awake()
        {
            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world, _sharedData);
            // NOTE: add your systems here
            _updateSystems.Add(new HouseInitSystem());

#if UNITY_EDITOR
            _updateSystems.Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            _updateSystems.Init();


            _fixUpdateSystems = new EcsSystems(_world, _sharedData);
            // NOTE: add your systems here
            _fixUpdateSystems.Add(new MovementSystem());

#if UNITY_EDITOR
            _fixUpdateSystems.Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            _fixUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems.Run();
        }

        private void FixedUpdate()
        {
            _fixUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            if (_updateSystems != null)
            {
                _updateSystems.Destroy();
                _updateSystems = null;
            }

            if (_fixUpdateSystems != null)
            {
                _fixUpdateSystems.Destroy();
                _fixUpdateSystems = null;
            }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }

        public EcsWorld GetWorld()
        {
            return _world;
        }
    }
}
