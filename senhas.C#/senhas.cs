using System;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Gerador de Senhas Seguras!");
            
            Console.Write("Digite o comprimento da senha (mínimo 8): ");
            int length = int.Parse(Console.ReadLine());
            
            if (length < 8)
            {
                Console.WriteLine("O comprimento mínimo é 8. Por favor, tente novamente.");
                return;
            }
            
            Console.Write("Incluir letras maiúsculas? (s/n): ");
            bool includeUppercase = Console.ReadLine()?.ToLower() == "s";

            Console.Write("Incluir números? (s/n): ");
            bool includeNumbers = Console.ReadLine()?.ToLower() == "s";

            Console.Write("Incluir caracteres especiais? (s/n): ");
            bool includeSpecial = Console.ReadLine()?.ToLower() == "s";

            string password = GeneratePassword(length, includeUppercase, includeNumbers, includeSpecial);
            Console.WriteLine($"Senha gerada: {password}");
        }

        static string GeneratePassword(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string special = "!@#$%^&*()-_=+<>?";

            StringBuilder characterPool = new StringBuilder(lowercase);

            if (includeUppercase) characterPool.Append(uppercase);
            if (includeNumbers) characterPool.Append(numbers);
            if (includeSpecial) characterPool.Append(special);

            if (characterPool.Length == 0)
            {
                throw new ArgumentException("Pelo menos um tipo de caractere deve ser incluído.");
            }

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characterPool.Length);
                password.Append(characterPool[index]);
            }

            return password.ToString();
        }
    }
}
