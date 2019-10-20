using UnityEngine;

public class MoveCube : MonoBehaviour
{
    Vector3 mousePos;
    private Rigidbody2D rb;
    Vector2 direction;
    private readonly float speed = 200f;
    private void Start() => rb = GetComponent<Rigidbody2D>();

    void CentreCube(float startX, float startY)
    {
        float closestX = startX, closestY = startY, minX = 10, minY = 10, abs;
        var posArray = CreateField.ReturnArray();
        for(int i = 0; i < 19; i++)
        {
            abs = Mathf.Abs(posArray[i, 0] - startX);
            if (abs < minX)
            {
                closestX = posArray[i, 0];
                minX = abs;
            }
            abs = Mathf.Abs(posArray[i, 1] - startY);
            if (abs < minY)
            {
                closestY = posArray[i, 1];
                minY = abs;
            }
        }
        rb.position = new Vector2 (closestX, closestY);
    }

    private void OnMouseUp()
    {
        CentreCube(rb.position.x, rb.position.y);
        rb.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - transform.position).normalized;
        rb.velocity = new Vector2(direction.x*speed, direction.y*speed);
    }
}
