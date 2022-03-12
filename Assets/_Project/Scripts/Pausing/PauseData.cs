using UnityEngine;

public class PauseData : ScriptableObject
{
    public delegate void OnPause();
    public event OnPause PauseEventHandler;

    bool _isPaused;

    public bool IsPaused
    {
        get { return _isPaused; }
        set
        {
            _isPaused = value;
            PauseEventHandler?.Invoke();
        }
    }

    void OnEnable() => _isPaused = false;
}