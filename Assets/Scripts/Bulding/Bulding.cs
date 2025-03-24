using UnityEngine;

public class Bulding : MonoBehaviour
{
    [SerializeField] private Renderer[] mainRendere;
    [SerializeField] private Vector2Int size = Vector2Int.one; 

    public Vector2Int SizeData()
    {
        return size;
    }

    public void SetTransparent(bool availabel)
    {
        for (int i = 0; i < mainRendere.Length; i++)
        {
            mainRendere[i].material.color = availabel ? Color.green : Color.red;
        }
    }

    public void SetNormal()
    {
        for (int i = 0; i < mainRendere.Length; i++)
        {
            mainRendere[i].material.color = Color.white;
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    Gizmos.color = new Color(0.88f, 1f, 0f, 0.3f);
                }
                else
                {
                    Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);
                }

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}
