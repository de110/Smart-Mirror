using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using UnityEditor.PackageManager;

public class clothing : MonoBehaviour
{
    GameObject cloth = null;
    public Text text;
    //string s;
    static string s;
    int num;
    int num2;
    //string st;
    public static bool EmotionCheck = false;
    public static bool reclothing = true;
    public static bool wt = false;
    static bool finished = false;
    int a;
    //Emotion e = new Emotion();
    //Emotion.AnnotateImageResponses res = new Emotion.AnnotateImageResponses();


    // Start is called before the first frame update
    void Start()
    {
        //EmotionCheck = false;
        a = 1;

        

    }

    // Update is called once per frame
    void Update()
    {
        //st = res.responses[0].faceAnnotations[0].joyLikelihood;
        //UnityEngine.Debug.Log(st);
        num = UnityEngine.Random.Range(1, 1000);
        num2 = UnityEngine.Random.Range(1, 1000);
        if(wt == true)
        {
            RandomCloth();
            wt = false;
        }


        if (EmotionCheck == false && reclothing == true && finished == false)
        {
            RandomCloth();
            reclothing = false;
        }
        if (EmotionCheck == true)
        {
            finished = true;
        }

        //a++;

    }


    public void RandomCloth()
    {
        s = GameObject.Find("Weather").GetComponent<Text>().text;
        double a = Convert.ToDouble(s);


        UnityEngine.Debug.Log(a);


        if ((a < 20) && (a > 0))
        {
            GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.SetActive(true);
            GameObject.Find("cloth").transform.Find("pants").gameObject.SetActive(true);


            if ((num % 5) == 0)
                GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            if ((num % 5) == 1)
                GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
            if ((num % 5) == 2)
                GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.gray;
            if ((num % 5) == 3)
                GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = new Color(245, 245, 220);
            if ((num % 5) == 4)
                GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;

            if ((num2 % 3) == 0)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            if ((num2 % 3) == 1)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
            if ((num2 % 3) == 2)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = new Color(245, 245, 220);


        }
        else if ((a >= 20) && (a < 25))
        {
            GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.SetActive(true);
            GameObject.Find("cloth").transform.Find("pants").gameObject.SetActive(true);

            if ((num % 5) == 0)
                GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
            if ((num % 5) == 1)
                GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            if ((num % 5) == 2)
                GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
            if ((num % 5) == 3)
                GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.GetComponent<MeshRenderer>().material.color = new Color(245, 245, 220);
            if ((num % 5) == 4)
                GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

            if ((num2 % 3) == 0)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            if ((num2 % 3) == 1)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
            if ((num2 % 3) == 2)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = new Color(245, 245, 220);


        }
        else if (a > 25)
        {
            GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.SetActive(true);
            GameObject.Find("cloth").transform.Find("pants").gameObject.SetActive(true);

            if ((num % 5) == 0)
                GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
            if ((num % 5) == 1)
                GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            if ((num % 5) == 2)
                GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
            if ((num % 5) == 3)
                GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.GetComponent<MeshRenderer>().material.color = new Color(245, 245, 220);
            if ((num % 5) == 4)
                GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

            if ((num2 % 3) == 0)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            if ((num2 % 3) == 1)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
            if ((num2 % 3) == 2)
                GameObject.Find("cloth").transform.Find("pants").gameObject.GetComponent<SkinnedMeshRenderer>().material.color = new Color(245, 245, 220);


        }
    }

    public void UnActiveCloth() 
    {
        GameObject.Find("cloth").transform.Find("long_sleeve").gameObject.SetActive(false);
        GameObject.Find("cloth").transform.Find("short_sleeve").gameObject.SetActive(false);
        GameObject.Find("cloth").transform.Find("sleeve_less").gameObject.SetActive(false);

        GameObject.Find("cloth").transform.Find("pants").gameObject.SetActive(false);
        
    }
}

