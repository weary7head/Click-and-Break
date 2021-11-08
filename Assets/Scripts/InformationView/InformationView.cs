using TMPro;
using UnityEngine;

public class InformationView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestResultText;
    [SerializeField] private TextMeshProUGUI _currentResultText;
    [SerializeField] private TextMeshProUGUI _playerHealthText;
    
    private int _points;
    private int _health;
    private int _bestPoints;

    public void SetPoints(int points)
    {
        _points = points;
        RefreshCurrentResultText();
    }

    public void SetHealth(int health)
    {
        _health = health;
        RefreshHealthText();
    }

    public void SetBestResult(int points)
    {
        _bestPoints = points;
        RefreshBestResultText();
    }

    private void RefreshCurrentResultText()
    {
        _currentResultText.text = $"Current result: {_points}";
    }
    
    private void RefreshBestResultText()
    {
        _bestResultText.text = $"The best result:  {_bestPoints}";
    }
    
    private void RefreshHealthText()
    {
        _playerHealthText.text = $"Player health:  {_health}";
    }
}
