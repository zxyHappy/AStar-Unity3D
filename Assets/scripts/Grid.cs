using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid : MonoBehaviour
{
    public float gridWidght;
    public float girdHeight;
    public bool isHinder;
    public Color color;
    public Action OnClick;
    //格子的坐标位置
    public int posX;
    public int posY;
    
    //计算预估路径长度三个值
    public int G = 0;
    public int H = 0;
    public int All = 0;
    
    public Grid parentGrid;

    private bool isHovered = false;

    private void OnMouseDown()
    {
        // 左键点击时触发 OnClick 事件
        OnClick?.Invoke();
    }

    private void OnMouseEnter()
    {
        // 光标进入物体时设置为悬停状态
        isHovered = true;
    }

    private void OnMouseExit()
    {
        // 光标离开物体时取消悬停状态
        isHovered = false;
    }

    private void OnGUI()
    {
        // 如果处于悬停状态，显示 G、H 和 All 的值
        if (isHovered)
        {
            // 设置 G、H 和 All 标签的固定屏幕位置
            Vector3 labelPosition = new Vector3(10, 10, 0); // 自定义位置

            // 创建自定义的GUIStyle，设置字体大小
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 16; // 设置字体大小为16

            GUI.Label(new Rect(labelPosition.x, labelPosition.y, 100, 20), "G: " + G, style);
            GUI.Label(new Rect(labelPosition.x, labelPosition.y + 20, 100, 20), "H: " + H, style);
            GUI.Label(new Rect(labelPosition.x, labelPosition.y + 40, 100, 20), "All: " + All, style);
        }
    }


    public void ChangeColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
        this.color = color;
    }
}