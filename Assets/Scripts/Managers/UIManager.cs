using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10;

    Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();
    UI_Scene _sceneUI = null;
    public GameObject root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_root");
            if (root == null)
                root = new GameObject { name = "@UI_root" };
            return root;

        }
    }
    public void SetCanvas(GameObject go, bool sort = true)
    {
        // Canvas Order ¼¼ÆÃ
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/WorldSpace/{name}");

        if (parent != null)
            go.transform.SetParent(parent);

        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        return go.GetOrAddComponent<T>();
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");

        if (parent != null)
            go.transform.SetParent(parent);
        
        return go.GetOrAddComponent<T>();
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(root.transform);

        return sceneUI;
    }
    public T ShowPopupUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        
        go.transform.SetParent(root.transform);

        return popup;
    }

    public void ClosePopupUI(UI_PopUp popup)
    {
        if (_popupStack.Count == 0)
            return;
        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup failed!");
            return;
        }
        ClosePopupUI();

    }
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0) return;

        UI_PopUp popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);

        popup = null;
        _order--;
    }
    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }

}
