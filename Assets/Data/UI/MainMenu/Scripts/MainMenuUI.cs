using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : UIBase
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _shopButton;
    void Start()
    {
        GameManager.Instance.ResumeGame();
        _playButton.onClick.RemoveAllListeners();
        _playButton.onClick.AddListener(LoadGameScene);

        _shopButton.onClick.RemoveAllListeners();
        _shopButton.onClick.AddListener(ShopUI.Instance.OpenPanel);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadGameScene()
    {
        PlayClickSFX();
        SceneManager.LoadScene("GameScene");
    }
}
