using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Games.Ball
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class GameInitSystem:SystemBase
    {
        
        
        protected override void OnCreate()
        {
            var gameData = EntityManager.CreateEntity();
            EntityManager.AddComponentData(gameData, new GameData());
        }

        protected override void OnUpdate()
        {
            // var Prefab = Resources.Load<GameObject>("MPrefab");// GameObject.Find("MPrefab");
            // Debug.Log(Prefab);
            // var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, new BlobAssetStore());
            // var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab,settings);
            // for (int i = 0; i < 4; i++)
            // {
            //     var entity = EntityManager.Instantiate(prefab);
            //     var translation = EntityManager.GetComponentData<Translation>(entity).Value;
            //     translation.x += i * 2;
            //     EntityManager.SetComponentData(entity, new Translation{Value = translation});
            // }

        }
    }
}