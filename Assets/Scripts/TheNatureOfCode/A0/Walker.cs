using Unity.Entities;
using Unity.Mathematics;

namespace TheNatureOfCode
{
    [GenerateAuthoringComponent]
    public struct Walker:IComponentData
    {
        public Random Random;
    }
}
