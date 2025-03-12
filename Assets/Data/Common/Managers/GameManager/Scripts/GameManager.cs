using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerControls _playerControls;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region GETTERS
    public PlayerControls PlayerControls => _playerControls;
    #endregion
}
