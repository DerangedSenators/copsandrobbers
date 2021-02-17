using Mirage;

namespace Me.DerangedSenators.CopsAndRobbers
{
#region Using

using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

/// <summary>
///     Generic singleton Class. Extend this class to make singleton component.
///     Example:
///     <code>
/// public class Foo : GenericSingleton<Foo>
///     </code>
///     . To get the instance of Foo class, use <code>Foo.instance</code>
///     Override <code>Init()</code> method instead of using <code>Awake()</code>
///     from this class.
/// </summary>
public abstract class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T _instance;

    [SerializeField, Tooltip("If set to true, the gameobject will deactive on Awake")] private bool _deactivateOnLoad;
    [SerializeField, Tooltip("If set to true, the singleton will be marked as \"don't destroy on load\"")] private bool _dontDestroyOnLoad;

    private bool _isInitialized;

    public static T instance
    {
        get
        {
            // Instance required for the first time, we look for it
            if (_instance != null)
            {
                return _instance;
            }

            var instances = Resources.FindObjectsOfTypeAll<T>();
            if (instances == null || instances.Length == 0)
            {
                return null;
            }

            _instance = instances.FirstOrDefault(i => i.gameObject.scene.buildIndex != -1);
            if (Application.isPlaying)
            {
                _instance?.Init();
            }
            return _instance;
        }
    }

    // If no other monobehaviour request the instance in an awake function
    // executing before this one, no need to search the object.
    protected virtual void Awake()
    {
        if (_instance == null || !_instance || !_instance.gameObject)
        {
            _instance = (T)this;
        }
        else if (_instance != this)
        {
            Debug.LogError($"Another instance of {GetType()} already exist! Destroying self...");
            Destroy(this);
            return;
        }
        _instance.Init();
    }

    /// <summary>
    ///     This function is called when the instance is used the first time
    ///     Put all the initializations you need here, as you would do in Awake
    /// </summary>
    public void Init()
    {
        Debug.Log($"Initialising Singleton ${instance.name}");
        if (_isInitialized)
        {
            return;
        }

        if (_dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (_deactivateOnLoad)
        {
            gameObject.SetActive(false);
        }

        SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;

        InternalInit();
        _isInitialized = true;
    }

    private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene scene)
    {
        // Sanity
        if (!instance || gameObject == null)
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            _instance = null;
            return;
        }

        if (_dontDestroyOnLoad)
        {
            return;
        }

        SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
        _instance = null;
    }

    protected abstract void InternalInit();

    /// Make sure the instance isn't referenced anymore when the user quit, just in case.
    private void OnApplicationQuit()
    {
        _instance = null;
    }

    void OnDestroy()
    {
        // Clear static listener OnDestroy
        SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;

        StopAllCoroutines();
        InternalOnDestroy();
        if (_instance != this)
        {
            return;
        }
        _instance = null;
        _isInitialized = false;
    }

    protected abstract void InternalOnDestroy();
}
}