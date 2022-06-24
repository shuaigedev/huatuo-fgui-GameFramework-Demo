using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPage : MonoBehaviour
{
    public Text Test1;
    // Start is called before the first frame update
    void Start()
    {
        //Test1 = transform.Find("Canvas/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Test1.text = "Hotfix test : " + Time.time.ToString();
    }
}
