using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityToolKits;

public class Grid<TCellObject>
{
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x, y;
    }

    private int _Nx, _Ny;
    private float _cellSize;
    private Vector3 _originPosition;
    private TCellObject[,] _gridArray;

    public Grid(int Nx, int Ny, float cellSize, Vector3 originPosition, Func<Grid<TCellObject>, int, int, TCellObject> defaultValue, bool showDebug = false)
    {
        _Nx = Nx;
        _Ny = Ny;
        _cellSize = cellSize;
        _originPosition = originPosition;
        _gridArray = new TCellObject[Nx, Ny];

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                _gridArray[x, y] = defaultValue(this, x, y);
            }
        }

        if (showDebug)
        {
            TextMesh[,] _debugTextArray= new TextMesh[Nx, Ny];
            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    _debugTextArray[x,y] = ToolKitClass.CreateWorldText(_gridArray[x,y]?.ToString(), null, GetWorldPosition(x,  y) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 10f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 10f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, Ny), GetWorldPosition(Nx, Ny), Color.white, 10f);
            Debug.DrawLine(GetWorldPosition(Nx, 0), GetWorldPosition(Nx, Ny), Color.white, 10f);
            OnGridValueChanged += (object sender, OnGridValueChangedEventArgs e) =>
            {
                _debugTextArray[e.x, e.y].text = _gridArray[e.x, e.y]?.ToString();
            };
        }

    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize + _originPosition;
    }
    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - _originPosition).x/_cellSize);
        y = Mathf.FloorToInt((worldPosition - _originPosition).y/_cellSize);
    }

    public void SetCellObject(int x, int y, TCellObject value)
    {
        if (x >= 0 && y >= 0 && x < _Nx && y < _Ny)
        {
            _gridArray[x, y] = value;
            OnGridValueChanged?.Invoke(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    public void TriggerCellObjectChanded(int x, int y)
    {
            OnGridValueChanged?.Invoke(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }

    public void SetCellObject(Vector3 worldPosition, TCellObject value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetCellObject(x, y, value);
    }

    public TCellObject GetCellObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < _Nx && y < _Ny)
            return _gridArray[x, y];
        else 
            return default(TCellObject);
    }
    public TCellObject GetCellObject(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetCellObject(x, y);
    }

}
