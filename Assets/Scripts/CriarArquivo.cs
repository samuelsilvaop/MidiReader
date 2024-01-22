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
        caminhoArquivo = Application.dataPath + "/notasMusicais.txt";

        // Lista de correspondência de notas científicas para nomes de notas
        Dictionary<char, string> correspondenciaNotas = new Dictionary<char, string>()
        {
            {'A', "Lá"},
            {'B', "Si"},
            {'C', "Dó"},
            {'D', "Ré"},
            {'E', "Mi"},
            {'F', "Fá"},
            {'G', "Sol"}
        };

        // Redirecionar as mensagens de log para um arquivo
        Application.logMessageReceived += (mensagem, stackTrace, tipoLog) =>
        {
            // Verificar se a mensagem contém uma nota musical (A2, B3, C4, etc.)
            if (mensagem.Length == 2 && correspondenciaNotas.ContainsKey(mensagem[0]) && char.IsDigit(mensagem[1]))
            {
                // Converter para o nome da nota e escrever no arquivo
                string nomeNota = correspondenciaNotas[mensagem[0]] + mensagem[1];
                EscreverArquivo(caminhoArquivo, nomeNota);
            }
        };
    }

    void EscreverArquivo(string caminho, string dados)
    {
        // Escrever os dados no arquivo, acrescentando uma quebra de linha
        File.AppendAllText(caminho, dados + "\n");
    }

    void OnDestroy()
    {
        // Remover o manipulador de log ao encerrar o jogo para evitar vazamentos de memória
        Application.logMessageReceived -= (mensagem, stackTrace, tipoLog) => {};
    }
}
