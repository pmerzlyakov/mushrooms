using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms.Rnd
{
    public class MovementStartup : MonoBehaviour
    {
        private const string MUSHROOM_TAG = "Mushroom";
        private const string TARGET_NAME = "EnemyTower";

        private EcsWorld _world;

        private Transform _target;

        private void Awake()
        {

        }

        private void Start()
        {
            _world = GameObject.FindObjectOfType<EcsStartup>().GetWorld();
            _target = GameObject.Find(TARGET_NAME).transform;

            var mushrooms = GameObject.FindGameObjectsWithTag(MUSHROOM_TAG);

            foreach (var m in mushrooms)
            {
                InitMushroom(m);
            }
        }

        private void InitMushroom(GameObject go)
        {
            int e = _world.NewEntity();

            var mushrooms = _world.GetPool<MushroomComponent>();
            var movements = _world.GetPool<MovementComponent>();
            var rbodies = _world.GetPool<UComponent<Rigidbody>>();

            ref MushroomComponent m = ref mushrooms.Add(e);
            m.House = 1;
            m.Team = 1;

            ref MovementComponent mv = ref movements.Add(e);
            mv.Speed = 2f;
            mv.Target = _target.position;

            ref UComponent<Rigidbody> rb = ref rbodies.Add(e);
            rb.Value = go.GetComponent<Rigidbody>();
        }
    }
}
