using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    [SerializeField] PauseData pauseData;

    bool timeFrozen = false;
    void OnEnable()
    {
        pauseData.PauseEventHandler += ToggleTimeFrozen;
    }

    void OnDisable()
    {
        pauseData.PauseEventHandler -= ToggleTimeFrozen;
    }

    void ToggleTimeFrozen()
    {
        timeFrozen = !timeFrozen;

        if (timeFrozen)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}