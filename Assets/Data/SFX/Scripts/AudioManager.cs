using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public EnemySFX enemySFX;
    public PlayerSFX playerSFX;
    public UISFX uiSFX;
    [HideInInspector] public AudioSource AudioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    [System.Serializable]
    public class PlayerSFX
    {
        public AudioClip ShootSFX;
    }

    [System.Serializable]
    public class EnemySFX
    {
        public AudioClip[] ZombieGrowl;
    }

    [System.Serializable]
    public class UISFX
    {
        public AudioClip UIClick;
    }
}
