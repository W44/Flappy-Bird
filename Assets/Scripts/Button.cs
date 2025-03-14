using UnityEngine;

public class Button: MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<GameManager>().Play();
        }

    }
}
