using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{

    private void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
