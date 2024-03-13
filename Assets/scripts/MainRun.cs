using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRun : MonoBehaviour
{
    // 获取网格创建脚本
    public GridMeshCreate gridMeshCreate;
    // 控制网格元素 grid 是否是障碍的概率
    [Range(0, 1)]
    public float probability;
    bool isCreateMap = false;
    int clickNum = 0;
    Grid startGrid;
    Grid endGrid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Run();
            isCreateMap = false;
            clickNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AStarLookRode aStarLookRode = new AStarLookRode();
            aStarLookRode.Init(gridMeshCreate, startGrid, endGrid);
            StartCoroutine(aStarLookRode.OnStart());
        }

        // 检测 ESC 键按下来退出程序
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }

    private void Run()
    {
        gridMeshCreate.gridEvent = GridEvent;
        gridMeshCreate.CreateMesh();
    }

    private void GridEvent(GameObject go, int row, int column)
    {
        // 概率随机决定该元素是否为障碍
        Grid grid = go.GetComponent<Grid>();
        float f = Random.Range(0, 1.0f);
        Color color = f <= probability ? Color.red : Color.white;
        grid.ChangeColor(color);
        grid.isHinder = f <= probability;
        grid.posX = row;
        grid.posY = column;
        // 模板元素点击事件
        grid.OnClick = () => {
            if (grid.isHinder)
                return;
            clickNum++;
            switch (clickNum)
            {
                case 1:
                    startGrid = grid;
                    grid.ChangeColor(Color.yellow);
                    break;
                case 2:
                    endGrid = grid;
                    grid.ChangeColor(Color.yellow);
                    isCreateMap = true;
                    break;
                default:
                    break;
            }
        };
    }

    // 退出应用程序方法
    private void QuitApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
