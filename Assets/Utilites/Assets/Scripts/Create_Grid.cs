using UnityEngine;
using UnityToolKits;

public class Create_Grid : MonoBehaviour 
{
    Grid<bool> grid;

    private void Start()
    {
        grid = new Grid<bool>(3,3,10f, new Vector3(-15f, -15f), (Grid<bool> g, int x, int y) => { return false; }, true);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetCellObject(ToolKitClass.GetMouseWorldPosition(), true);
        }
    }

}
