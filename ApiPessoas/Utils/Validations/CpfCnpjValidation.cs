using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiPessoas.Utils.Validations
{
    public class CpfCnpjValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true; // Não faz validação se o valor for nulo

            string input = value.ToString();

            if (IsCpf(input) || IsCnpj(input))
                return true;

            return false;
        }

        private bool IsCpf(string input)
        {
            // Implemente a lógica de validação de CPF aqui
            // Retorne true se for válido, false caso contrário
            // Exemplo simplificado (verifique um formato específico)
            return Regex.IsMatch(input, @"^\d{11}$");
        }

        private bool IsCnpj(string input)
        {
            // Implemente a lógica de validação de CNPJ aqui
            // Retorne true se for válido, false caso contrário
            // Exemplo simplificado (verifique um formato específico)
            return Regex.IsMatch(input, @"^\d{14}$");
        }
    }
}
