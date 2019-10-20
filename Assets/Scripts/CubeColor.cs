using UnityEngine;

public class CubeColor : MonoBehaviour
{
    int random;
    void Start()
    {
        random = Random.Range(1, 4);
        random = CheckColor();
       switch(random)
        {
            case 1:
                GetComponent<Renderer>().material.color = Color.green;
                CreateField.countGreen++;
                break;
            case 2:
                GetComponent<Renderer>().material.color = Color.red;
                CreateField.countRed++;
                break;
            case 3:
                GetComponent<Renderer>().material.color = Color.blue;
                CreateField.countBlue++;
                break;
        }
    }

    int CheckColor()
    {
        if (random == 1 && CreateField.countGreen != 5)
            return 1;
        else if (random == 2 && CreateField.countRed != 5)
            return 2;
        else if (random == 3 && CreateField.countBlue != 5)
            return 3;
        else
        {
            random = Random.Range(1, 4);
            return CheckColor();
        }
    }
}
