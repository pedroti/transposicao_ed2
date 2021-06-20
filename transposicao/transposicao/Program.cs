using System;

namespace transposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            string senha = "ultimo";
            string texto = "Às vezes ouço passar o vento; e só de ouvir o vento passar, vale a pena ter nascido.";
            Console.WriteLine("Texto: " + texto);
            string cripto = criptografar(senha, texto);
            Console.WriteLine("Texto criptografado: " + cripto);
            string descripto = descriptografar(senha, cripto);
            Console.WriteLine("Texto descriptografado: " + descripto);
        }

        private static string descriptografar(string senha, string texto)
        {
            int tamanhoSenha = senha.Length;
            int n = texto.Length / tamanhoSenha;
            char[] vetorAux = senha.ToCharArray();
            char[,] mat = new char[n + 1, 6];
            Array.Sort(vetorAux);
            for (int i = 0; i < tamanhoSenha; i++)
            {
                mat[0, i] = senha.ToCharArray()[i];
            }

            int k = 0;
            int cont = 0;
            while (k < tamanhoSenha )
            {
                int pos = 0;
                for (int j = 0; j < senha.Length; j++)
                {
                    if (mat[0, j] == vetorAux[k])
                    {
                        pos = j;
                        k++;
                        break;
                    }
                }


                for (int h = 1; h <= n && cont < texto.Length; h++)
                {
                    mat[h, pos] = texto.ToCharArray()[cont];
                    cont++;
                }
            }
            string deVoltaProNormal = "";

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 0; j < tamanhoSenha; j++)
                {
                    deVoltaProNormal += mat[i, j];
                }
            }
    
            return deVoltaProNormal;
        }

        private static string criptografar(string senha, string texto)
        {
            int tamanhoSenha = senha.Length;
            char[] vetorAux = senha.ToCharArray();
            char[,] mat = new char[99, tamanhoSenha];
            Array.Sort(vetorAux);

            for (int i = 0; i < tamanhoSenha; i++)
            {
                mat[0, i] = senha.ToCharArray()[i];
            }
            int cont = 0;
            for (int i = 1; i < texto.Length; i++)
            {
                for (int j = 0; j < tamanhoSenha; j++)
                {
                    mat[i, j] = texto.ToCharArray()[cont];
                    cont++;
                    if (cont == texto.Length)
                    {
                        break;
                    }
                }
                if (cont == texto.Length)
                {
                    break;
                }
            }

            string criptografado = "";
            int k = 0;
            while (k < tamanhoSenha)
            {
                int pos = 0;
                for (int i = 0; i < senha.Length; i++)
                {
                    if (mat[0, i] == vetorAux[k])
                    {
                        pos = i;
                        break;
                    }
                }
                for (int i = 1; i < texto.Length; i++)
                {
                    if (mat[i, pos] != '\0')
                    {
                        criptografado += mat[i, pos];
                    }
                }
                k++;
            }

            return criptografado;
        }
    }
}
