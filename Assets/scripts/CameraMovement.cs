using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 7.5f;
    public float verticalSpeed = 600f;

    private void Update()
    {
        // 获取鼠标滚轮输入
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // 获取W和S键输入
        float verticalInput = Input.GetAxis("Vertical");

        // 获取A和D键输入
        float horizontalInput = Input.GetAxis("Horizontal");

        // 计算前后移动方向
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // 移动相机前进或后退
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 计算竖直移动
        Vector3 verticalMove = new Vector3(0f, 0f, scrollInput) * verticalSpeed;

        // 移动相机竖直方向
        transform.Translate(verticalMove * Time.deltaTime);
    }
}