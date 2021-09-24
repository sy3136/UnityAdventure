using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;

        //List<GameObject> list = new List<GameObject>();
        //for (int i = 0; i < 5; i++)
        //    list.Add(Managers.Resource.Instantiate("UnityChan"));

        //Managers.Resource.Destroy(list[0]);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }
    public override void Clear()
    {
        Debug.Log("Login Scene Clear");
    }
}
