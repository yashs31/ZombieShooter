using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void PlayClickSFX()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.uiSFX.UIClick);
    }

    public virtual void OpenPanel()
    {
        PlayClickSFX();
    }

    public virtual void ClosePanel()
    {
        PlayClickSFX();
    }
}
