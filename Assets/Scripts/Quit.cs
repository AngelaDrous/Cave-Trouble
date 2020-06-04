using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    [SerializeField]
    KeyCode keyEscape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyEscape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
