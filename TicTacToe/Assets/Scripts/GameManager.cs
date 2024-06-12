using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CellState _lastMove;
    private CellData[,] _board = new CellData[3, 3];
    [SerializeField] private Cell[] _cells;
    [SerializeField] private EndGamePanel _endGamePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private BoxCollider2D[] _triggers;

    // Start is called before the first frame update

    void Start()
    {
        Initalize();
        //Debug.Log(GameSettings.isPvP);
    }

    private void Initalize()
    {
        foreach (Cell cell in _cells)
        {
            _board[cell.GetRow, cell.GetCol] = new CellData();
            _board[cell.GetRow, cell.GetCol].cellObject = cell;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetactivePausePanel(true);
            BoxColliderSetActive(false);
        }
    }

    public void Move(CellState player, int row, int col)
    {
        if (_board[row, col].state == CellState.None)
        {
            _board[row, col].state = player;
            _lastMove = player;

            CheckMove(player);
        }
    }

    public void CheckMove(CellState player)
    {
        if (CheckForWinner(player))
        {
            Debug.Log("Winner " + player);
            _endGamePanel.Display(player);
            BoxColliderSetActive(false);
        }
        else if (IsBoardFull() == true)
        {
            Debug.Log("Draw");
            _endGamePanel.Display(CellState.None);
            BoxColliderSetActive(false);
        }
        else if (GameSettings.gameMode == GameMode.PvE)
        {
            if (_lastMove == CellState.Circle)
            {
                return;
            }
            AIMove();
        }
    }

    public CellState GetNextMove()
    {
        if (_lastMove == CellState.None)
        {
            return CellState.Cross;
        }
        if (_lastMove == CellState.Cross)
        {
            return CellState.Circle;
        }
        if (_lastMove == CellState.Circle)
        {
            return CellState.Cross;
        }
        return CellState.None;
    }

    private bool CheckForWinner(CellState player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_board[i, 0].state == player && _board[i, 1].state == player && _board[i, 2].state == player)
            {
                return true;
            }
            if (_board[0, i].state == player && _board[1, i].state == player && _board[2, i].state == player)
            {
                return true;
            }
        }

        if (_board[0, 0].state == player && _board[1, 1].state == player && _board[2, 2].state == player)
        {
            return true;
        }
        if (_board[2, 0].state == player && _board[1, 1].state == player && _board[0, 2].state == player)
        {
            return true;
        }
        return false;
    }

    private bool IsBoardFull()
    {
        for(int i = 0;i < 3;i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board[i, j].state == CellState.None)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void AIMove()
    {
        Debug.Log("Bot made move");

        

        List<CellData> emptyCells = new List<CellData>();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board[i, j].state == CellState.None)
                {
                    emptyCells.Add(_board[i, j]);
                }
            }
        }

        int emptyCellsCount = emptyCells.Count;
        int randomCellIndex = UnityEngine.Random.Range(0, emptyCellsCount);
        CellData randomCell = emptyCells[randomCellIndex];
        randomCell.cellObject.AISelected();
    }

    public void BoxColliderSetActive(bool isActive)
    {
        foreach (BoxCollider2D collider in _triggers)
        {
            collider.enabled = isActive;
        }
    }

    public void SetactivePausePanel(bool isActive)
    {
        _pausePanel.SetActive(isActive);
        BoxColliderSetActive(!isActive);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



[Serializable]
public class CellData
{
    public CellState state;
    public Cell cellObject;
}
