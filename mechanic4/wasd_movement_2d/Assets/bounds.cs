using UnityEngine.SceneManagement;
using UnityEngine;

public class bounds : MonoBehaviour
{
    void OnTriggerEnter2D() {
        SceneManager.LoadScene("SampleScene");
    }
}
