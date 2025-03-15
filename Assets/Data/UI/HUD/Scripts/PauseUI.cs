using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : UIBase
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _exitButton;
    [SerializeField] GameObject _overlay;
    [SerializeField] Animator _animator;
    public static PauseUI Instance;
    private void Awake()
    {
        // Singleton Behaviour
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
        _playButton.onClick.RemoveAllListeners();
        _playButton.onClick.AddListener(ClosePanel);

        _exitButton.onClick.RemoveAllListeners();
        _exitButton.onClick.AddListener(LoadMainMenu);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadMainMenu()
    {
        PlayClickSFX();
        SceneManager.LoadScene("MainMenu");
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        _animator.SetBool("isOpen", true);
        _overlay.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        _animator.SetBool("isOpen", false);
        _overlay.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}
