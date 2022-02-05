using Leopotam.EcsLite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mushrooms
{
    public class SpawnSystem : IEcsRunSystem
    {
        // int entity = world.NewEntity ();

        // private EcsFilter<MushroomComponent> murshrooms;

        public void Run(EcsSystems systems)
        {
        // {
        //           // test creating and removing entites in loop.
        //     var entity = _world.CreateEntity ();
        //     _world.AddComponent<UnityIntegrationComponent1> (entity);
        //     _world.RemoveEntity (entity);

        //     // change component field in loop.
        //     foreach (var c2entity in _filter.Entities) {
        //         _world.GetComponent<UnityIntegrationComponent2> (c2entity).Time = Time.time;
        //     }

        //     foreach (var i in shoots)
        //     {
        //         ref var hitComponent = ref shoots.Get1(i);

        //         foreach(var j in playerFilter)
        //         {
        //             ref var playerComponent = ref playerFilter.Get1(i);

        //             if (hitComponent.other.CompareTag("WinPoint"))
        //             {
        //                 playerComponent.playerTransform.gameObject.SetActive(false);
        //                 playerFilter.GetEntity(i).Destroy();
        //                 gameData.playerWonPanel.SetActive(true);
        //             }

        //             if (hitComponent.other.CompareTag("JumpBuff"))
        //             {
        //                 hitComponent.other.gameObject.SetActive(false);
        //                 playerComponent.playerJumpForce *= 2f;
        //                 ref var jumpBuffComponent = ref playerFilter.GetEntity(i).Get<JumpBuffComponent>();
        //                 jumpBuffComponent.timer = gameData.configuration.jumpBuffDuration;
        //             }

        //             if (hitComponent.other.CompareTag("SpeedBuff"))
        //             {
        //                 hitComponent.other.gameObject.SetActive(false);
        //                 playerComponent.playerSpeed *= 2f;
        //                 ref var speedBuffComponent = ref playerFilter.GetEntity(i).Get<SpeedBuffComponent>();
        //                 speedBuffComponent.timer = gameData.configuration.speedBuffDuration;
        //             }
        //         }
                
        //     }
        }
    }
}