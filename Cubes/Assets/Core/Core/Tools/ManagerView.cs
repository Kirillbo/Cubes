using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerView : SingltoonBehavior<ManagerView>
{

    [SerializeField]
    private GameObject[] _defaultPanels;
    [SerializeField]
    private GameObject _background;
    
    public Transform DynamicCanvas;
    
    private  Dictionary<Type, BaseUI> _views = new Dictionary<Type, BaseUI>();
    
//    public T Get<T>(Transform tr = null) where T : BaseUI
//    {
//        
//        var keyType = typeof(T);
//
//        if (_views.ContainsKey(keyType))
//        {
//            var o = _views[keyType];
//            return o as T;
//        }
//
//        var result = GameManager.Instance.ViewContainer.AllView.First(n => n.GetType() == typeof(T));
//
//        Transform parent;
//        parent = result.GetTypeCanvas() == TypeCanvas.Dynamic ? DynamicCanvas : transform;
//        
//        var copyView = Instantiate(result, parent);
//        copyView.Init();
//        copyView.Close();
//       _views.Add(keyType, copyView);
//        return copyView as T;
//    }
    
    public  void Dispose()
    {
        _views.Clear();
    }

    public ManagerView BackGround(bool val, float alphaBackground = 1)
    {
        
        _background.SetActive(val);
        return this;
    }

    public void CloseAll()
    {
        var allView = _views.Values;
        foreach (var v in allView)
            v.Close();

    }
    
    private void OnDestroy()
    {
        Dispose();
    }
}
