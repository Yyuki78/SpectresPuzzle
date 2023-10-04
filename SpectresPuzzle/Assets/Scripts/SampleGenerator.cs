using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGenerator : MonoBehaviour
{
    [SerializeField] GameObject Spectres;

    void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        float ran, rotate;
        while (true)
        {
            ran = Random.Range(-5f, 5f);
            rotate = Random.Range(0f, 360f);
            Instantiate(Spectres, new Vector3(ran, 4.9f, 0), Quaternion.EulerAngles(0, 0, rotate), transform);
            yield return wait;
        }
    }
}
