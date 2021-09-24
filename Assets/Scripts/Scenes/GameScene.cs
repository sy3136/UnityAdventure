using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    // Coroutine
    // 함수의 상태를 저장/복원 가능
    // 엄청 오래걸리는 작업을 잠시 끊거나 원하는 타이밍에 함수를 잠시 stop/복원하는 경우

    // return -> 우리가 원하는 타입으로 가능 (class도 가능)

    Coroutine co;
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        
        //Managers.UI.ShowSceneUI<UI_Inven>();
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        gameObject.GetOrAddComponent<CursorController>();

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        //Managers.Game.Spawn(Define.WorldObject.Monster, "DogKnight");
        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        pool.SetKeepMonsterCount(5);

    }
    //IEnumerator CoStopExplode(float seconds)
    //{
    //    Debug.Log("Stop enter");
    //    yield return new WaitForSeconds(seconds);
    //    Debug.Log("Stop Execute");
    //    if (co != null)
    //    {
    //        StopCoroutine(co);
    //        co = null;
    //    }
    //}

    //IEnumerator CoExplodeAfterSeconds(float seconds)
    //{
    //    Debug.Log("Explode Enter");
    //    yield return new WaitForSeconds(seconds);
    //    Debug.Log("Explode Execute");
    //    co = null;
    //}

    public override void Clear()
    {
    }
    void Update()
    {
        
    }
}
