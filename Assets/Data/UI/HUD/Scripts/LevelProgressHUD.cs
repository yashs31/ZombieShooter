using TMPro;
using UnityEngine;

public class LevelProgressHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _zombieText;
    [SerializeField] TextMeshProUGUI _waveText;
    void Start()
    {
        Events.UpdateZombieCount += UpdateZombieCount;
        Events.UpdateWaveCount += UpdateWaveCount;
    }

    private void OnDisable()
    {
        Events.UpdateZombieCount -= UpdateZombieCount;
        Events.UpdateWaveCount -= UpdateWaveCount;
    }

    private void UpdateZombieCount(int spawned, int max)
    {
        _zombieText.text = spawned + " / " + max;
    }
    private void UpdateWaveCount(int currentWave)
    {
        _zombieText.text = "Wave " + currentWave;
    }
}
