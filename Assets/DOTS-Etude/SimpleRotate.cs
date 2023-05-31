using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace DOTSEtude
{
    public partial struct SimpleRotate : ISystem 
    { 
        public void OnCreate(ref SystemState state)
        {
            Entity entity = state.EntityManager.CreateEntity();
            state.EntityManager.AddComponent<LocalTransform>(entity);
        }

        public void OnUpdate(ref SystemState state)
        {
            new MyJobs { }.ScheduleParallel();
        }
    }
}

public partial struct MyJobs : IJobEntity
{
    public void Execute(ref LocalTransform transform)
    {
        transform.Position += math.up();
        transform.Rotation = new quaternion(0f, 2f, 0f, 0f);
    }
}