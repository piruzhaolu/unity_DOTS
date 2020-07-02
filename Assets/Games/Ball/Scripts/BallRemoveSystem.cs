using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Games.Ball
{
    public class BallRemoveSystem:SystemBase
    {
    
        
        EndSimulationEntityCommandBufferSystem m_EndSimulationEcbSystem;
        
        protected override void OnCreate()
        {
            m_EndSimulationEcbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        public int Count = 0;

        protected override void OnUpdate()
        {
            var gameDataEntity = GetEntityQuery(ComponentType.ReadWrite<GameData>()).GetSingletonEntity();
            
            var ecb = m_EndSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();
            Entities.ForEach((Entity entity,int entityInQueryIndex, in Translation translation, in Ball ball) =>
            {
                if (translation.Value.z > 25f )
                {
                    ecb.DestroyEntity(entityInQueryIndex,entity); 
                    var c = GetComponent<GameData>(gameDataEntity);
                    c.Value += 1;
                    SetComponent(gameDataEntity, c);
                }
                if (translation.Value.y < -30f)
                {
                    ecb.DestroyEntity(entityInQueryIndex,entity);
                }
            }).Schedule();
            m_EndSimulationEcbSystem.AddJobHandleForProducer(Dependency);
            
        }
    }
}