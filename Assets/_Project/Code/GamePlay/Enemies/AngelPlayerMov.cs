using UnityEngine;
using UnityEngine.InputSystem;

public class AngelPlayerMov : MonoBehaviour
{
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition); mouseWorldPosition.z = 0;
        transform.position = mouseWorldPosition;
    }
}
