using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using Unity.Transforms;
using UnityEngine;
using Unity.Physics;

namespace Games.Ball
{
    public class BallResetSystem:SystemBase
    {

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
                var e = _entityQuery.GetSingletonEntity();
                // var e = GetEntityQuery(ComponentType.ReadOnly<Ball>(), ComponentType.ReadOnly<Prefab>())
                //     .GetSingletonEntity();
                
                var inst = EntityManager.Instantiate(e);
                EntityManager.RemoveComponent<Prefab>(inst);
                
                var newPv = EntityManager.GetComponentData<PhysicsVelocity>(e);
                newPv.Linear = new float3();
                EntityManager.SetComponentData(inst,newPv);
                EntityManager.SetComponentData(inst,new Translation{Value = new float3(5.28f, -10.59f, -22.53f)});
                

                // Entities
                //     .WithAll<Ball>()
                //     .ForEach((Entity e, ref PhysicsVelocity pv, ref Translation translation) =>
                //     {
                //         
                //         var inst = base.EntityManager.Instantiate(e);
                //
                //         var newPv = pv;
                //         newPv.Linear = new float3(0);
                //         EntityManager.SetComponentData(inst,newPv);
                //         var newPos = translation;
                //         newPos.Value = new float3(5.28f, -10.59f, -22.53f);
                //         EntityManager.SetComponentData(inst,newPos);
                //     }).Run();
            }
        }
    }
}