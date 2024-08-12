using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int corDaVez, acertos, erros;
    public int[] sequencia;
    [SerializeField] public string[] nomes;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GerarSequencia();
    }

    public void GerarSequencia()
    {
        corDaVez = 0;
        UiManager.instance.LimparTexto();
        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = Random.Range(0, nomes.Length);
            UiManager.instance.AtualizarSequencia(nomes[sequencia[i]]);
        }
    }

    public void ChecarCor(int corIndex)
    {
        if(sequencia[corDaVez] == corIndex)
        {
            corDaVez++; 

         if(corDaVez == sequencia.Length)
            {
                acertos++;
                UiManager.instance.AtualizarAcertos(acertos);
                GerarSequencia();
            }
        } 
        else
        {
            erros++;
            UiManager.instance.AtualizarErros(erros);
            GerarSequencia();
        }
       
    }
}