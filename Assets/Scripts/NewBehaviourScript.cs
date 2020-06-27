using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//
// public class MoveSystem : SystemBase
// {
//     protected override void OnUpdate()
//     {
//         var t = Time.DeltaTime;
//         Entities.ForEach((ref Translation translation) =>
//         {
//             translation.Value+= new float3(0,0,0.1f * t);
//         }).Schedule();
//     }
// }