using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CriarArquivo_old : MonoBehaviour
{
    // Caminho do arquivo (pode ser modificado conforme necessário)
    private string caminhoArquivo;

    void Start()
    {
        caminhoArquivo = Application.dataPath + "/notasMusicais.txt";

        // Redirecionar as mensagens de log para um arquivo
        Application.logMessageReceived += LogHandler;
    }

    void LogHandler(string mensagem, string stackTrace, LogType tipoLog)
    {
        // Verificar se a mensagem contém uma nota musical (A2, B3, C4, etc.)
        if (mensagem.Length == 2 && char.IsLetter(mensagem[0]) && char.IsDigit(mensagem[1]))
        {
            // Escrever a nota musical no arquivo
            EscreverArquivo(caminhoArquivo, mensagem);
        }
    }

    void EscreverArquivo(string caminho, string dados)
    {
        // Escrever os dados no arquivo, acrescentando uma quebra de linha
        File.AppendAllText(caminho, dados + "\n");
    }

    void OnDestroy()
    {
        // Remover o manipulador de log ao encerrar o jogo para evitar vazamentos de memória
        Application.logMessageReceived -= LogHandler;
    }
}
