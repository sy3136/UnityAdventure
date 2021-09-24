using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장하기.
    static Managers Instance { get { Init(); return s_instance; } } // 유일한 매니저 갖고오기.

    #region Content
    GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }
    #endregion

    #region Core
    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    SceneMangerEx _scene = new SceneMangerEx();
    SoundManger _sound = new SoundManger();

    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SceneMangerEx Scene { get { return Instance._scene; } }
    public static SoundManger Sound { get { return Instance._sound; } }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
    }
    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            //Data
            s_instance._data.Init();

            //Pool
            s_instance._pool.Init();

            //Sound
            s_instance._sound.Init();
        }

    }
    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
    }
}
