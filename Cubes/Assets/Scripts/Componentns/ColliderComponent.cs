using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

[Game]
public class ColliderComponent : IComponent
{

	public Transform SourceObject;
	public Transform SecondObject;
	public bool DamageHeart;
	public Entity SecondEntity;
}
