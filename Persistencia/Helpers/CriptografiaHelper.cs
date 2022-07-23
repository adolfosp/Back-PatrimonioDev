using System;

namespace Persistencia.Helpers
{
    public static class CriptografiaHelper
    {

        public static string Criptografar(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve um erro ao criptografar a senha. Mensagem: {ex.Message}");
            }
        }

        public static string Descriptografar(string stringCriptografada)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(stringCriptografada);

            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

            char[] decoded_char = new char[charCount];

            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

            return new string(decoded_char);
        }

    }
}
