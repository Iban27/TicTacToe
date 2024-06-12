using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private GameManager _gameManager;
    private CellState _currentCellState;
    [SerializeField] private int _row;
    [SerializeField] private int _col;
    public int GetRow => _row;
    public int GetCol => _col;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //_spriteRenderer.sprite = _sprites[0];

        if (_gameManager.GetNextMove() == CellState.Circle && GameSettings.gameMode == GameMode.PvE)
            return;

        PlayerSelected();

    }

    private void PlayerSelected()
    {
        Selected();
    }

    public void AISelected()
    {
        if (_gameManager.GetNextMove() == CellState.Cross)
        {
            return;
        }
        Selected();
    }

    private void Selected()
    {
        if (_currentCellState == CellState.None)
        {
            if (_gameManager.GetNextMove() == CellState.Cross)
            {
                _spriteRenderer.sprite = _sprites[1];
                _currentCellState = CellState.Cross;
            }
            if (_gameManager.GetNextMove() == CellState.Circle)
            {
                _spriteRenderer.sprite = _sprites[0];
                _currentCellState = CellState.Circle;
            }

            _gameManager.Move(_currentCellState, _row, _col);

        }
    }
}

public enum CellState
{
    None,
    Cross,
    Circle
}
