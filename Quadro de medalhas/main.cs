using System;

class ProgramaMedalhas
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] paises = new string[N];
        int[,] medalhas = new int[N, 3];

        // Leitura dos dados de entrada
        for (int i = 0; i < N; i++)
        {
            string[] entrada = Console.ReadLine().Split(' ');
            paises[i] = entrada[0];
            medalhas[i, 0] = int.Parse(entrada[1]); // Ouro
            medalhas[i, 1] = int.Parse(entrada[2]); // Prata
            medalhas[i, 2] = int.Parse(entrada[3]); // Bronze
        }

        // Ordenação com base nas regras de ouro, prata, bronze e nome
        for (int i = 0; i < N - 1; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                // Comparação pelo número de medalhas de ouro
                if (medalhas[i, 0] < medalhas[j, 0])
                {
                    Trocar(i, j, paises, medalhas);
                }
                else if (medalhas[i, 0] == medalhas[j, 0])
                {
                    // Se empatar em ouro, comparar pelas medalhas de prata
                    if (medalhas[i, 1] < medalhas[j, 1])
                    {
                        Trocar(i, j, paises, medalhas);
                    }
                    else if (medalhas[i, 1] == medalhas[j, 1])
                    {
                        // Se empatar em prata, comparar pelas medalhas de bronze
                        if (medalhas[i, 2] < medalhas[j, 2])
                        {
                            Trocar(i, j, paises, medalhas);
                        }
                        else if (medalhas[i, 2] == medalhas[j, 2])
                        {
                            // Se empatar em tudo, comparar alfabeticamente
                            if (paises[i].CompareTo(paises[j]) > 0) // Substituindo String.Compare
                            {
                                Trocar(i, j, paises, medalhas);
                            }
                        }
                    }
                }
            }
        }

        // Exibindo o resultado
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"{paises[i]} {medalhas[i, 0]} {medalhas[i, 1]} {medalhas[i, 2]}");
        }
    }

    static void Trocar(int i, int j, string[] paises, int[,] medalhas)
    {
        // Troca os países
        string tempPais = paises[i];
        paises[i] = paises[j];
        paises[j] = tempPais;

        // Troca as medalhas
        for (int k = 0; k < 3; k++)
        {
            int tempMedalha = medalhas[i, k];
            medalhas[i, k] = medalhas[j, k];
            medalhas[j, k] = tempMedalha;
        }
    }
}
