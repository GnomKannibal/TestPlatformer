using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportHouse : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F)) SceneManager.LoadScene("AirLevel");
    }
}
