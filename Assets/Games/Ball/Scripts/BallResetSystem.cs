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

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Entities
                    .WithAll<Ball>()
                    .ForEach((ref PhysicsVelocity pv, ref Translation translation) =>
                    {
                        pv.Linear = new float3(0);
                        translation.Value = new float3(5.28f, -10.59f, -22.53f);
                    }).Run();
            }
        }
    }
}