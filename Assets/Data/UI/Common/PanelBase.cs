using UnityEngine;

public class PanelBase : MonoBehaviour
{
    public virtual void PlayClickSFX()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.uiSFX.UIClick);
    }
}
