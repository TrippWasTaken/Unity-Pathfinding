using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProperties : MonoBehaviour
{
    Color[] colors = new Color[3];
    int ColInd;
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.green;
        colors[1] = Color.red;
        colors[2] = Color.blue;
        StartCol();
        StartCoroutine(Time());
    }

    void StartCol()
    {
        ColInd = Random.Range(0, colors.Length);
        Color CurrCol = colors[ColInd];
        gameObject.GetComponent<Renderer>().material.color = CurrCol;
    }
    void ChangeCol(int ind)
    {
        if(ind == 0)
        {
            Color CurrCol = colors[1];
            ColInd = 1;
            gameObject.GetComponent<Renderer>().material.color = CurrCol;
        }
        if (ind == 1)
        {
            Color CurrCol = colors[2];
            ColInd = 2;
            gameObject.GetComponent<Renderer>().material.color = CurrCol;
        }
        if (ind == 2)
        {
            Color CurrCol = colors[0];
            ColInd = 0;
            gameObject.GetComponent<Renderer>().material.color = CurrCol;
        }
    }

    IEnumerator Time()
    {
        int RandTime;
        if (ColInd == 0)
        {
            gameObject.name = "Green";
            gameObject.tag = "Green";
            RandTime = Random.Range(5, 10);
            yield return new WaitForSeconds(RandTime);
            ChangeCol(ColInd);
        }
        if (ColInd == 1)
        {
            gameObject.name = "Red";
            gameObject.tag = "Null";
            RandTime = Random.Range(5, 10);
            yield return new WaitForSeconds(RandTime);
            ChangeCol(ColInd);
        }
        if (ColInd == 2)
        {
            gameObject.name = "Blue";
            gameObject.tag = "Null";
            yield return new WaitForSeconds(4);
            ChangeCol(ColInd);
        }
        StartCoroutine(Time());
    }
}
