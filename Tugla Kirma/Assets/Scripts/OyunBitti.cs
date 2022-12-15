using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{
    public TextMeshProUGUI puan;
    // Start is called before the first frame update
    void Start()
    {
        puan.text =" Puanýnýz:" + GameObject.FindObjectOfType<Puan>().GetComponent<Puan>().PuaniAl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnaSahneyeGec()
    {
        SceneManager.LoadScene(1);
    }
}
