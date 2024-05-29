using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTopController : NguyenMonoBehaviour
{
    public GameObject tooltip;  // Đối tượng chứa Text (Tooltip)
    public Text tooltipText;  // Sử dụng Text thường
    // public TMP_Text tooltipText;  // Sử dụng TextMeshPro nếu dùng TextMeshPro

    protected override void Start()
    {
        // Ẩn tooltip ban đầu
        tooltip.SetActive(false);
    }

    // Hàm để hiển thị tooltip
    public void ShowTooltip(string message)
    {
        tooltip.SetActive(true);
        tooltipText.text = message;
    }

    // Hàm để ẩn tooltip
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    // Hàm để di chuyển tooltip theo con trỏ chuột
    public void SetTooltipPosition(Vector2 position)
    {
        tooltip.transform.position = position;
    }
}
