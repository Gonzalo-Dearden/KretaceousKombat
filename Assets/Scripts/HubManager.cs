using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    public GlobalGameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Arena()
    {
        SceneManager.LoadScene("Battle");
    }
}
