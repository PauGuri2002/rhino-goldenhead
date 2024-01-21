using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(true);
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel(){
        yield return new WaitForSeconds(2);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level" + (int.Parse(currentScene[currentScene.Length-1].ToString()) + 1));
    } 
}
