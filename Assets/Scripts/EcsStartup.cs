using UnityEngine;
using Leopotam.EcsLite;

namespace Mushrooms
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private SceneData _sharedData;
        [SerializeField] private MovementBehaviour _inputManager;

        private EcsWorld _world;

        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();

            if ((object)_inputManager != null)
            {
                _inputManager.SetWorld(_world);
            }

            _updateSystems = new EcsSystems(_world);
            _updateSystems.Add(new HouseInitSystem());
            _updateSystems.Add(new SpawnSystem());
            _updateSystems.Add(new StartMovementSystem());
#if UNITY_EDITOR
            _updateSystems.Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            _updateSystems.Init();

            _fixedUpdateSystems = new EcsSystems(_world, _sharedData);
            _fixedUpdateSystems.Add(new MovementSystem());
#if UNITY_EDITOR
            _fixedUpdateSystems.Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            if (_updateSystems != null)
            {
                _updateSystems.Destroy();
                _updateSystems = null;
            }

            if (_fixedUpdateSystems != null)
            {
                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;
            }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}
