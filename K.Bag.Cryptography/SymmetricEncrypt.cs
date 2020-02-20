using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace K.Bag.Cryptography
{
	internal static class SymmetricEncrypt
	{
		/// <summary>
		/// Cria um string criptografada com o Algorítimo Simétrico utilizando uma chave
		/// </summary>
		/// <param name="plainText">Texto a ser criptografado</param>
		/// <param name="secret">Chave de criptografia (Deve ser utilizada a mesma para que seja desfeita)</param>
		/// <returns>String criptografada</returns>
		public static string ToSymmetricEncrypt(this string plainText, string key)
		{
			byte[] iv = new byte[16];
			byte[] array;

			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.Default.GetBytes(key.ToMD5());
				aes.IV = iv;

				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
						{
							streamWriter.Write(plainText);
						}
						array = memoryStream.ToArray();
					}
				}
			}
			return array.ToBase64UrlString();
		}



		/// <summary>
		/// Cria um string descriptografada com o Algorítimo Simétrico utilizando uma chave
		/// </summary>
		/// <param name="cypherText">Texto a ser descriptografado</param>
		/// <param name="secret">Chave de criptografia (A mesma utilizada na criptografia)</param>
		/// <returns>String descriptografada</returns>
		public static string ToSymmetricDecrypt(this string cypherText, string key)
		{
			byte[] iv = new byte[16];
			byte[] buffer = Convert.FromBase64String(cypherText.FromBase64UrlToBase64());

			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.Default.GetBytes(key.ToMD5());
				aes.IV = iv;

				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader streamReader = new StreamReader(cryptoStream))
						{
							return streamReader.ReadToEnd();
						}
					}
				}
			}

		}
	}
}
