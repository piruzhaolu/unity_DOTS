using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Games.Ball
{
    
    public class GameInitSystem:SystemBase
    {
        protected override void OnCreate()
        {
            var gameData = EntityManager.CreateEntity();
            EntityManager.AddComponentData(gameData, new GameData{BallCount = 30});
        }

        private bool _isStart = false;
        protected override void OnStartRunning()
        {
            if (_isStart) return;
            var e = GetEntityQuery(ComponentType.ReadOnly<Ball>()).GetSingletonEntity();
            EntityManager.AddComponent<Prefab>(e); //TODO: 制作一个Prefab。这里无法以比较合适的时机创建Prefab
            
            var wall = GetEntityQuery(ComponentType.ReadOnly<Wall>()).GetSingletonEntity();
            
            EntityManager.SetComponentData(wall, new Translation{Value = new float3(-5.5f,-21.424f,18.7f)});
            for (var i = 1; i < 6; i++)
            {
                wall = EntityManager.Instantiate(wall);
                EntityManager.SetComponentData(wall, new Translation{Value = new float3(-5.5f+i*5,-21.424f,18.7f)});
            }
            
            _isStart = true;
        }


        protected override void OnUpdate()
        {
        }
    }
}