using UnityEngine;

public class CreateField : MonoBehaviour
{
    public GameObject wallbox;
    public GameObject gamebox;
    public GameObject winObject;
    private GameObject boxs;
    public static GameObject nameWinObject;
    private int count = 0;
    public static int countGreen = 0, countBlue = 0, countRed = 0;
    private static float[,] posArray;
    private void Awake()
    {
        countBlue = 0;
        countGreen = 0;
        countRed = 0;
    }
    void OnCreateField(float x, float y, GameObject box)
    {
        Vector3 myPos = new Vector3(x, y, 0);
        if(box == gamebox) { 
            boxs = Instantiate(box, myPos, Quaternion.identity);
            boxs.name = "game" + count;
            count++;
        }
        else Instantiate(box, myPos, Quaternion.identity);
    }

    void Start()
    {
        int count = 0;
        posArray = new float[19, 2];
        var redCube = GameObject.Find("RedCube");
        redCube.GetComponent<Renderer>().material.color = Color.red;
        var greenCube = GameObject.Find("GreenCube");
        greenCube.GetComponent<Renderer>().material.color = Color.green;
        var blueCube = GameObject.Find("BlueCube");
        blueCube.GetComponent<Renderer>().material.color = Color.blue;
        nameWinObject = Instantiate(winObject, new Vector3(-3.53f, -0.06f, -2f), Quaternion.identity);
        nameWinObject.name = "winstext";
        nameWinObject.SetActive(false);
        for (int i = 0; i != 7; i++) { 
            OnCreateField(-6.55f + i, 3.53f, wallbox);
            OnCreateField(-6.55f + i, -2.47f, wallbox);
            OnCreateField(-6.55f, 3.53f - i, wallbox);
            OnCreateField(-0.55f, 3.53f - i, wallbox);
        }
        OnCreateField(-4.55f,2.53f, wallbox);
        OnCreateField(-4.55f, -1.47f, wallbox);
        OnCreateField(-2.55f, 2.53f, wallbox);
        OnCreateField(-2.55f, -1.47f, wallbox);
        OnCreateField(-4.55f, 0.53f, wallbox);
        OnCreateField(-2.55f, 0.53f, wallbox);
        for (int i = 0; i != 5; i++)
        {
            for(int j = 0; j !=5; j++)
                if(j != 1 && j != 3)
                { 
                    OnCreateField(-5.55f + j, 2.53f - i, gamebox);
                    posArray[count, 0] = -5.55f + j;
                    posArray[count, 1] = 2.53f - i;
                    count++;
                }
        }
        posArray[15, 0] = -4.55f;
        posArray[15, 1] = 1.53f;
        posArray[16, 0] = -2.55f;
        posArray[16, 1] = 1.53f;
        posArray[17, 0] = -4.55f;
        posArray[17, 1] = -.47f;
        posArray[18, 0] = -2.55f;
        posArray[18, 1] = -.47f;
    }

    static public float[,] ReturnArray()
    {
        return posArray;
    }
}
