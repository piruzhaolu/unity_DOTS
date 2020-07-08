using Unity.Entities;

namespace Games.Ball
{
    [GenerateAuthoringComponent]
    public struct GameData:IComponentData
    {
        public int Value;
        public int BallCount;
    }
}