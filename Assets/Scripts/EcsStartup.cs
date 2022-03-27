using UnityEngine;
using Leopotam.EcsLite;

namespace Mushrooms
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        [SerializeField] 
        private SceneData _sharedData;

        private void Start()
        {
            _world = new EcsWorld();
            
            _updateSystems = new EcsSystems(_world);
            _updateSystems.Init();
            
            _fixedUpdateSystems = new EcsSystems(_world, _sharedData);
            _fixedUpdateSystems.Add(new HouseInitSystem());
            _fixedUpdateSystems.Add(new SpawnSystem());
            _fixedUpdateSystems.Add(new MovementSystem());
            _fixedUpdateSystems.Add(new HouseVisualizeSystem());
           
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
            if (_updateSystems != null) {
                _updateSystems.Destroy();
                _updateSystems = null;
            }

            if (_fixedUpdateSystems != null) {
                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;
            }

            if (_world != null) {
                _world.Destroy();
                _world = null;
            }
        }
    }
}