using Unity.Entities;
using Unity.Mathematics;

namespace TheNatureOfCode
{
    
    [GenerateAuthoringComponent]
    public struct WalkerNoise:IComponentData
    {
        public float2 Value;
    }
}