using UnityEngine;
using UnityEngine.InputSystem;

public class AngelPlayerMov : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public Camera _camera;

    void Update()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, _camera.nearClipPlane));
        Vector3 direccion = (mouseWorldPosition - transform.position).normalized;
        transform.position += direccion * velocidadMovimiento * Time.deltaTime;
    }
}