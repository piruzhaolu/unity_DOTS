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

        public int InitValue = 30;
        protected override void OnStartRunning()
        {
            var e = GetEntityQuery(ComponentType.ReadOnly<Ball>()).GetSingletonEntity();
            EntityManager.AddComponent<Prefab>(e);
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
                if (InitValue == 0) return;
                var e = _entityQuery.GetSingletonEntity();
                
                var inst = EntityManager.Instantiate(e);
                EntityManager.RemoveComponent<Prefab>(inst);
                
                var newPv = EntityManager.GetComponentData<PhysicsVelocity>(e);
                newPv.Linear = new float3();
                EntityManager.SetComponentData(inst,newPv);
                EntityManager.SetComponentData(inst,new Translation{Value = new float3(5.28f, -10.59f, -22.53f)});
                InitValue--;
                GameObject.Find("Amount").GetComponent<TMP_Text>().text = InitValue.ToString();

            }
        }
    }
}