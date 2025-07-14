using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportHouse : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(index + 1);
        if (Input.GetKeyDown(KeyCode.F)) SceneManager.LoadScene(index + 1);
    }
}
