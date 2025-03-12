using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [HideInInspector] public PlayerControls Controls;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        Controls = new PlayerControls();
        Controls.Player.Enable();
        Controls.UI.Enable();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
