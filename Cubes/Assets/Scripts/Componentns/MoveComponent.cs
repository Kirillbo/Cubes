using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


    public class MoveComponent : IComponent
    {
        public float Speed;
        [EntityIndex]
        public Transform Transform;
    }

