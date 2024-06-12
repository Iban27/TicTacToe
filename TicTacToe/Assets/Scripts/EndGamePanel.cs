using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private TextMeshProUGUI _statisticText;
    private int _crossWinCount;
    private int _circleWinCount;
    private int _drawCount;

    // Start is called before the first frame update
    void Start()
    {
        _crossWinCount = PlayerPrefs.GetInt("CROSS");
        _circleWinCount = PlayerPrefs.GetInt("CIRCLE");
        _drawCount = PlayerPrefs.GetInt("DRAW");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(CellState winner)
    {
        _endGamePanel.SetActive(true);

        if (winner == CellState.Cross)
        {
            _winnerText.text = "Cross";
            _crossWinCount++;
        }
        else if (winner == CellState.Circle)
        {
            _winnerText.text = "Circle";
            _circleWinCount++;
        }
        else if (winner == CellState.None)
        {
            _winnerText.text = "Draw";
            _drawCount++;
        }
        SaveStatistic();
        DisplayStatistic();
    }

    public void SaveStatistic()
    {
        PlayerPrefs.SetInt("CROSS", _crossWinCount);
        PlayerPrefs.SetInt("CIRCLE", _circleWinCount);
        PlayerPrefs.SetInt("DRAW", _drawCount);
    }

    public void DisplayStatistic()
    {
        _statisticText.text = "Cross: " + _crossWinCount + "\n" + "Circle: " + _circleWinCount + "\n" + "Draw: " + _drawCount;
    }
}
