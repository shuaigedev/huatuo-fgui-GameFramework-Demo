using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAOTPage : MonoBehaviour
{
    public Text Test1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Test1.text = "AOT Scripte Test : " +Time.time.ToString();
    }
}
