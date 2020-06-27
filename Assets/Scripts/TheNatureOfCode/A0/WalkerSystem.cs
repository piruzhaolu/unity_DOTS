using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace TheNatureOfCode
{
    [DisableAutoCreation]
    public class WalkerSystem:SystemBase
    {
      
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;
            
            Entities.ForEach((ref Walker walker, ref Translation translation) =>
            {
                
                var randomFloat3 = walker.Random.NextFloat3(new float3(-1, 0, -1), new float3(1, 0, 1.1f));
                translation.Value += randomFloat3 * deltaTime * 20f;

            }).Schedule();

        }
    }
    
    
    public class WalkerSystemNoise:SystemBase
    {
      
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;
            
            Entities.ForEach((ref WalkerNoise walker, ref Translation translation) =>
            {
                var x = noise.snoise(new float2(walker.Value.x,0));
                var y = noise.snoise(new float2(0,walker.Value.y));
                translation.Value += new float3(x, 0, y) * deltaTime*10;
                
                walker.Value+=new float2(0.1f,0.1f);
            }).Schedule();

        }
    }
}