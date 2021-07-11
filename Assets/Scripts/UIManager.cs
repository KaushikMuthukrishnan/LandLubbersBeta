using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels = new GameObject[4];
    public GameObject[] shipPrefabs = new GameObject[4];
    public Transform player;
    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Time.timeScale = 0f;
        ActivatePanel(0, true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && panels[2].activeInHierarchy)
            Pause();
    }

    private void OnGUI()
    {
        GUILayout.TextField(Mathf.RoundToInt(1/Time.unscaledDeltaTime).ToString());
    }
    private void ActivatePanel(int index, bool freezeTime) 
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
                panels[i].SetActive(true);
            else
                panels[i].SetActive(false);
        }
        Time.timeScale = freezeTime ? 0f : 1f;
        Cursor.lockState = freezeTime ? CursorLockMode.None : CursorLockMode.Confined;
    } 
    public void Pause()
    {
        ActivatePanel(3, true);
        Cursor.visible = true;

    }
    public void Play()
    {
        ActivatePanel(2, false);
        Cursor.visible = false;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectLarge() 
    {
        SelectPlayer(2);
    }
    public void SelectMidPlus() 
    {
        SelectPlayer(3);
    }
    public void SelectMid() 
    {
        SelectPlayer(1);
    }
    public void SelectSmall() 
    {
        SelectPlayer(0);
    }
    public void ChangeCharPanel()
    {
        ActivatePanel(1, true);
        Cursor.visible = true;
    }

    private void SelectPlayer(int index)
    {
        GameObject originalPlayerVFX = player.GetChild(0).gameObject;
        Quaternion rotation = originalPlayerVFX.transform.rotation;
        Destroy(originalPlayerVFX);
        Instantiate(shipPrefabs[index], player.position, rotation, player).transform.SetAsFirstSibling();
        ActivatePanel(2, false);
        Cursor.visible = false;
    }
}
