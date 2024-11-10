using System;
using System.Collections.Generic;

class ListaCrianças
{
    static void Main()
    {
        // Leitura do número de crianças
        int N = int.Parse(Console.ReadLine());

        // Lista para comportadas e não comportadas
        List<string> todasAsCrianças = new List<string>();
        int comportadasCount = 0;
        int naoComportadasCount = 0;

        // Leitura dos nomes e categorização
        for (int i = 0; i < N; i++)
        {
            string linha = Console.ReadLine();
            char comportamento = linha[0]; // '+' ou '-'
            string nome = linha.Substring(2); // Nome da criança

            // Contar comportadas e não comportadas
            if (comportamento == '+')
            {
                comportadasCount++;
            }
            else
            {
                naoComportadasCount++;
            }

            // Adicionar todos os nomes em uma lista
            todasAsCrianças.Add(nome);
        }

        // Ordenação manual usando Bubble Sort
        for (int i = 0; i < todasAsCrianças.Count - 1; i++)
        {
            for (int j = 0; j < todasAsCrianças.Count - i - 1; j++)
            {
                if (Comparar(todasAsCrianças[j], todasAsCrianças[j + 1]) > 0)
                {
                    // Troca as posições se não estiverem em ordem alfabética
                    string temp = todasAsCrianças[j];
                    todasAsCrianças[j] = todasAsCrianças[j + 1];
                    todasAsCrianças[j + 1] = temp;
                }
            }
        }

        // Exibir os nomes em ordem alfabética
        foreach (string nome in todasAsCrianças)
        {
            Console.WriteLine(nome);
        }

        // Exibir a contagem de comportadas e não comportadas
        Console.WriteLine($"Se comportaram: {comportadasCount} | Nao se comportaram: {naoComportadasCount}");
    }

    // Função de comparação alfabética
    static int Comparar(string a, string b)
    {
        int tamanho = Math.Min(a.Length, b.Length);
        for (int i = 0; i < tamanho; i++)
        {
            if (a[i] < b[i])
            {
                return -1;
            }
            else if (a[i] > b[i])
            {
                return 1;
            }
        }

        // Se todas as letras forem iguais até o menor tamanho, comparar pelo tamanho
        if (a.Length < b.Length) return -1;
        else if (a.Length > b.Length) return 1;
        else return 0;
    }
}
