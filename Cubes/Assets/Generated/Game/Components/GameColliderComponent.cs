//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ColliderComponent collider { get { return (ColliderComponent)GetComponent(GameComponentsLookup.Collider); } }
    public bool hasCollider { get { return HasComponent(GameComponentsLookup.Collider); } }

    public void AddCollider(UnityEngine.Transform newSourceObject, UnityEngine.Transform newSecondObject, bool newDamageHeart) {
        var index = GameComponentsLookup.Collider;
        var component = (ColliderComponent)CreateComponent(index, typeof(ColliderComponent));
        component.SourceObject = newSourceObject;
        component.SecondObject = newSecondObject;
        component.DamageHeart = newDamageHeart;
        AddComponent(index, component);
    }

    public void ReplaceCollider(UnityEngine.Transform newSourceObject, UnityEngine.Transform newSecondObject, bool newDamageHeart) {
        var index = GameComponentsLookup.Collider;
        var component = (ColliderComponent)CreateComponent(index, typeof(ColliderComponent));
        component.SourceObject = newSourceObject;
        component.SecondObject = newSecondObject;
        component.DamageHeart = newDamageHeart;
        ReplaceComponent(index, component);
    }

    public void RemoveCollider() {
        RemoveComponent(GameComponentsLookup.Collider);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollider;

    public static Entitas.IMatcher<GameEntity> Collider {
        get {
            if (_matcherCollider == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Collider);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollider = matcher;
            }

            return _matcherCollider;
        }
    }
}