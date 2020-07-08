using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Games.Ball
{
    public class WallSystem:SystemBase
    {
        
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;
            Entities
                .WithAll<Wall>()
                .ForEach((ref Translation translation) =>
                {
                    if (translation.Value.x < -10)
                    {
                        var newValue = translation.Value;
                        newValue.x = 20f;
                        translation.Value = newValue;
                    }
                    translation.Value -= new float3(1f, 0, 0) * deltaTime;

                }).Schedule();

        }
    }
    
    
    
}