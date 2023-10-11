using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectresManager : MonoBehaviour
{
    public enum GameState
    {

    }
    public GameState _currentState;

    //���̐}�`
    public int currentSpectres;

    //�z�u�ς݂̐}�`�B
    public List<SpectresMove> ALLSpectres = new List<SpectresMove>();

    //Prefab
    public GameObject[] SpectresPrefabs = new GameObject[6];

    void Start()
    {
        Invoke("FirstSet", 0.1f);
    }

    private void FirstSet()
    {
        int ran;
        do
        {
            ran = Random.Range(1, SpectresPrefabs.Length + 1);
        } while (ran == 4);
        currentSpectres = ran;
        for (int i = 0; i < ALLSpectres.Count; i++)
            ALLSpectres[i].ShowNextSpectres(currentSpectres);
    }
    
    public void SetNextSpectres()
    {
        int ran = Random.Range(1, SpectresPrefabs.Length + 1);
        currentSpectres = ran;
        //�S�Ă̔z�u�ςݐ}�`�ɗ\�����o������
        for (int i = 0; i < ALLSpectres.Count; i++)
        {
            ALLSpectres[i].ShowNextSpectres(currentSpectres);
        }
    }

    public void GenerareSpectres(Vector2 pos)
    {
        GameObject instance = Instantiate(SpectresPrefabs[currentSpectres - 1], pos, SpectresPrefabs[currentSpectres - 1].transform.rotation, transform);
        ALLSpectres.Add(instance.GetComponent<SpectresMove>());

        SetNextSpectres();
    }
}
