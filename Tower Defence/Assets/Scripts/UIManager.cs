using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _towerPanel;
    [SerializeField] private GameObject _nextWavePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _upperPanel;

    [SerializeField] private Buildmanager _buildmanager;
    [SerializeField] private WaveSpawner _waveSpawner;

    [SerializeField] private TMP_Text _waveNumber;
    [SerializeField] private TMP_Text _coinAmount;
    [SerializeField] private TMP_Text _waveSurvived;

    private void Awake()
    {

        _towerPanel = GameObject.FindGameObjectWithTag("TowerPanel");
        _nextWavePanel = GameObject.FindGameObjectWithTag("NextwavePanel");
        _gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        _upperPanel = GameObject.FindGameObjectWithTag("UpperPanel");

    }

    private void Start()
    {
        _towerPanel.SetActive(true);
        _nextWavePanel.SetActive(false);
        _upperPanel.SetActive(true);
        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        _waveNumber.text = _waveSpawner._wavesNumber.ToString("00");
        _waveSurvived.text = (_waveSpawner._wavesNumber - 1).ToString("00");
        _coinAmount.text = _buildmanager._coinAmount.ToString("000");
        if(GameManager.instance._isGameOver == true)
        {
            _towerPanel.SetActive(false);
            _nextWavePanel.SetActive(true);
            _upperPanel.SetActive(false);
            _gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
