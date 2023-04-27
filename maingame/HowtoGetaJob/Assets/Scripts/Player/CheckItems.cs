using UnityEngine;

public class CheckItems : MonoBehaviour
{
    public float radius = 2f; // 检查半径
    public LayerMask layerMask; // 道具所在的图层

    public void GetItem()
    {
        // 使用 OverlapSphere 获取主角周围的碰撞器数组
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        // 遍历数组检查是否有道具的碰撞器
        foreach (Collider collider in colliders)
        {
            // 判断是否是道具的碰撞器
            if (collider.CompareTag("Item"))
            {
                // 执行相应的操作，比如将道具添加到主角的背包中
                Debug.Log("Found an item: " + collider.gameObject.name);
                Player.Instance.DressItem(collider.gameObject);
            }
        }
    }

    // 绘制检查半径的球体辅助线，方便调试
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}