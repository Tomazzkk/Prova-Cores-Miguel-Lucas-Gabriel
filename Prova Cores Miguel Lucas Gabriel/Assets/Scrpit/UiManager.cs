using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Button[] botoes;
    [SerializeField] TextMeshProUGUI sequenciaTexto, acertouTexto, errouTexto;

    #region Singleton
   public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
   public  void Start()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i;
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x));
        }
    }

    public void AtualizarAcertos(int acertos)
    {
        acertouTexto.text = acertos.ToString("0");
    }
    public void AtualizarErros(int erros)
    {
        errouTexto.text = erros.ToString("0");
    }

    public void LimparTexto()
    {
        sequenciaTexto.text = ToString();
    }

    public void AtualizarSequencia(string cor )
    {

        sequenciaTexto.text = cor.ToString();
    }
}