using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CriarArquivo : MonoBehaviour
{
    // Caminho do arquivo (pode ser modificado conforme necessário)
    private string caminhoArquivo;

    void Start()
    {
        caminhoArquivo = Application.dataPath + "/logDoJogo.txt";

        // Redirecionar as mensagens de log para um arquivo
        Application.logMessageReceived += LogHandler;
    }

    void LogHandler(string mensagem, string stackTrace, LogType tipoLog)
    {
        // Criar uma string formatada com a mensagem de log
        string logFormatado = $"{tipoLog.ToString()}: {mensagem}\n{stackTrace}\n\n";

        // Escrever a string formatada no arquivo
        EscreverArquivo(caminhoArquivo, logFormatado);
    }

    void EscreverArquivo(string caminho, string dados)
    {
        // Escrever os dados no arquivo
        File.AppendAllText(caminho, dados);
    }

    void OnDestroy()
    {
        // Remover o manipulador de log ao encerrar o jogo para evitar vazamentos de memória
        Application.logMessageReceived -= LogHandler;
    }
}
