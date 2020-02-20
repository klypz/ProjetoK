using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K.Bag
{
    /// <summary>
    /// Gera uma string aleatória com base nas instruções
    /// <code>
    /// //Gera uma senha com 14 caracteres e todos os caracteres habilitados
    /// string password = PasswordGenerator.NewPassword()
    /// //Gera uma senha com 20 caracteres e todos os caracteres habilitados
    /// string password = PasswordGenerator.NewPassword(20)
    /// //Gera uma senha com 14 caracteres e não inclui caracteres mai
    /// string password = PasswordGenerator.NewPassword(upperChar: false)
    /// </code>
    /// </summary>
    public static class PasswordGenerator
    {
        /// <summary>
        /// Método para gerar uma sequencia de caracteres aleatório. 
        /// </summary>
        /// <param name="size">Quantidade de Caracteres</param>
        /// <param name="upperChar">Autorizar uso de letras maiuscula</param>
        /// <param name="lowerChar">Autorizar uso de letras minusula</param>
        /// <param name="number">Autorizar uso de número</param>
        /// <param name="special">Autorizar uso de caracteres especiais</param>
        /// <returns>Retorna uma string aleatóris</returns>
        public static string NewPassword(int size = 14, bool upperChar = true, bool lowerChar = true, bool number = true, bool special = true)
        {
            List<char[]> listChar = new List<char[]>();

            if (upperChar)
            {
                listChar.Add(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' });
            }

            if (lowerChar)
            {
                listChar.Add(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' });
            }

            if (number)
            {
                listChar.Add(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            }

            if (special)
            {
                listChar.Add(new char[] { '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=', '-', ':', '>', '<' });
            }

            int fator = size / listChar.Count();

            StringBuilder output = new StringBuilder();
            Random rdm = new Random();

            listChar.ForEach(f =>
            {
                for (int i = 0; i < fator; i++)
                {
                    output.Append(f[rdm.Next(0, f.Count() - 1)]);
                }
            });

            if (output.Length < size)
            {
                for (int i = 0; i < (size - output.Length) + 1; i++)
                {
                    int row = rdm.Next(0, listChar.Count());
                    output.Append(listChar[row][rdm.Next(0, listChar[row].Count() - 1)]);
                }
            }

            char[] array = output.ToString().ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            return new string(array);
        }
    }
}
