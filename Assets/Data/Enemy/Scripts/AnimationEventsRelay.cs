using UnityEngine;
using UnityEngine.Events;

public class AnimationEventsRelay : MonoBehaviour
{
    public UnityEvent OnAnimationEventTriggered; // UnityEvent to trigger on animation complete

    public void OnAttackEventTrigger()
    {
        OnAnimationEventTriggered?.Invoke();
    }
}
