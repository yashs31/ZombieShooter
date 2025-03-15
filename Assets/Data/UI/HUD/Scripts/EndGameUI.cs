using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : UIBase
{
    [SerializeField] Button _restartButton;
    [SerializeField] Button _menuButton;
    [SerializeField] GameObject _overlay;
    [SerializeField] Animator _animator;
    public static EndGameUI Instance;
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
        Events.GameEnd -= OpenPanel;
        Events.GameEnd += OpenPanel;
        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(RestartScene);

        _menuButton.onClick.RemoveAllListeners();
        _menuButton.onClick.AddListener(LoadMenu);

    }

    private void OnDisable()
    {
        Events.GameEnd -= OpenPanel;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void RestartScene()
    {
        PlayClickSFX();
        SceneManager.LoadScene("GameScene");
    }
    private void LoadMenu()
    {
        PlayClickSFX();
        GameManager.Instance.ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
    public override void OpenPanel()
    {
        base.OpenPanel();
        _animator.SetBool("isOpen", true);
        _overlay.SetActive(true);
        GameManager.Instance.PauseGame();
    }
}
