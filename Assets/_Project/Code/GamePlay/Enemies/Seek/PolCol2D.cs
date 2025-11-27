using System.Collections.Generic;
using UnityEngine;

public class PolCol2D : MonoBehaviour
{
    private PolygonCollider2D poly;
    private SpriteRenderer sr;
    private Sprite lastSprite;

    void Awake()
    {
        poly = GetComponent<PolygonCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (sr.sprite == null)
            return;
        if (sr.sprite == lastSprite)
            return;

        lastSprite = sr.sprite;

        // Borrar paths anteriores
        poly.pathCount = 0;

        int shapeCount = sr.sprite.GetPhysicsShapeCount();
        poly.pathCount = shapeCount;

        // List reusable
        List<Vector2> points = new List<Vector2>();

        for (int i = 0; i < shapeCount; i++)
        {
            points.Clear();                                // limpiar antes de volver a usar
            sr.sprite.GetPhysicsShape(i, points);
            poly.SetPath(i, points.ToArray());
        }
    }
}
