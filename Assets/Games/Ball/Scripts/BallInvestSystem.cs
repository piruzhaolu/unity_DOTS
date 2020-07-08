using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using Unity.Transforms;
using UnityEngine;
using Unity.Physics;

namespace Games.Ball
{
    public class BallInvestSystem:SystemBase
    {

        protected override void OnStartRunning()
        {
            _entityQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] {ComponentType.ReadOnly<Ball>(), ComponentType.ReadOnly<Prefab>()},
                Options = EntityQueryOptions.IncludePrefab
            });
        }


        private EntityQuery _entityQuery;

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var gameData = GetSingleton<GameData>();
                if (gameData.BallCount == 0) return;
                var e = _entityQuery.GetSingletonEntity();
                
                var inst = EntityManager.Instantiate(e);
                EntityManager.RemoveComponent<Prefab>(inst);
                
                var newPv = EntityManager.GetComponentData<PhysicsVelocity>(e);
                newPv.Linear = new float3();
                EntityManager.SetComponentData(inst,newPv);
                EntityManager.SetComponentData(inst,new Translation{Value = new float3(5.28f, -10.59f, -22.53f)});
                gameData.BallCount--;
                SetSingleton(gameData);
                
                GameObject.Find("Amount").GetComponent<TMP_Text>().text = gameData.BallCount.ToString();

            }
        }
    }
}