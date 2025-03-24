using Assets.Scripts.Conservation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BuldingsGrit : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize = new Vector2Int(10, 10);
    [SerializeField] private Bulding[] buldings;
    [SerializeField] private Button postButton;

    private Input input;
    private Bulding[,] grid;
    private Bulding flyingBulding;
    private Example example;
    private Camera mainCamera;
    private Vector2 MousePos;
    private int indexHouse;

    private void Awake()
    {
        example = GetComponent<Example>();
        input = GetComponent<Input>();
        grid = new Bulding[gridSize.x, gridSize.y];
        mainCamera = Camera.main;
        postButton.interactable = false;
    }

    private void Update()
    {
        if (flyingBulding != null)
        {
            MousePos = Mouse.current.position.ReadValue();
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(MousePos);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0 || x > gridSize.x - flyingBulding.SizeData().x)
                {
                    available = false;
                }

                if (y < 0 || y > gridSize.y - flyingBulding.SizeData().y)
                {
                    available = false;
                }

                if (available && IsPlaceTaken(x, y))
                {
                    available = false;
                }

                flyingBulding.transform.position = new Vector3(x, 0, y);
                flyingBulding.SetTransparent(available);

                if (available && input.click)
                {
                    PlaceFlyingBulding(x, y);
                    input.click = false;
                    example.Save();
                }
            }
        }  
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBulding.SizeData().x; x++)
        {
            for (int y = 0; y < flyingBulding.SizeData().y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBulding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBulding.SizeData().x; x++)
        {
            for (int y = 0; y < flyingBulding.SizeData().y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBulding;
            }
        }

        flyingBulding.SetNormal();
        flyingBulding = null;
    }

    public void StartPlacingBulding(int index)
    {
        indexHouse = index;
        postButton.interactable = true;
    }

    public void ButtonPost()
    {
        if (flyingBulding != null)
        {
            Destroy(flyingBulding.gameObject);
        }

        flyingBulding = Instantiate(buldings[indexHouse]);

        postButton.interactable = false;
        input.click = false;
    }
}
