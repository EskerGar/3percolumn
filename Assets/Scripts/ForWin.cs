using UnityEngine;

public class ForWin : MonoBehaviour
{
    private Rigidbody2D rb;
    int countGreen = 0;
    int countRed = 0;
    int countBlue = 0;
    float xPos = 0;
    private GameObject go;
    Color materialCol;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseUp()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        for (int i = 0; i != 15; i++)
        {
            go = GameObject.Find("game" + i);
            Renderer ren = go.GetComponent<Renderer>();
            xPos = go.transform.position.x;
            materialCol = ren.material.color;
            CountColor(ref countRed, xPos, -5f, -6f, Color.red, materialCol);
            CountColor(ref countGreen, xPos, -3f, -4f, Color.green, materialCol);
            CountColor(ref countBlue, xPos, -1f, -2f, Color.blue, materialCol);
    }
        if (countRed == 5 && countGreen == 5 && countBlue == 5)
            CreateField.nameWinObject.SetActive(true);
        countGreen = 0;
        countBlue = 0;
        countRed = 0;

        void CountColor(ref int count, float x, float max, float min, Color color, Color materialColor)
    {
        if (x > min && x < max && materialColor == color)
            count++;
    }
}
}
