using UnityEngine;
using UnityEngine.InputSystem;

public class DeleteBulding : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private bool activeDelete;
    [SerializeField] private Input input;
    private Vector2 MousePos;
    private void Start()
    {
        mainCamera = Camera.main;
        activeDelete = false;
    }

    private void Update()
    {
        if (activeDelete)
        {
            DeleteObgiect();
        }
        MousePos = Mouse.current.position.ReadValue();
    }

    private void DeleteObgiect()
    {
        if (input.click)
        {
            Ray ray = mainCamera.ScreenPointToRay(MousePos);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "CanBeDeleted")
                {
                    Destroy(hit.transform.gameObject);
                    activeDelete = false;
                    input.click = false;
                }
            }
        }
    }

    public void ButtonActivatorDeletting()
    {
        activeDelete = true;
        input.click = false;
    }
}
