using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using trayprojeto45;
using Xunit;

namespace TestTray.TestEntities
{

    public class PessoaTests
    {
        [Fact]
        public void Pessoa_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var nome = "João Silva";
            var email = "joao@email.com";
            var senha = "senha123";

            // Act
            var pessoa = new Pessoa(nome, email, senha);

            // Assert
            Assert.Equal(nome, pessoa.Nome);
            Assert.Equal(email, pessoa.Email);
            Assert.Equal(senha, pessoa.Senha);
        }

        [Fact]
        public void Pessoa_DefaultConstructor_SetsPropertiesToDefault()
        {
            // Act
            var pessoa = (Pessoa)typeof(Pessoa)
                .GetConstructor(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, new System.Type[0], null)
                ?.Invoke(null);

            // Assert
            Assert.NotNull(pessoa);
            Assert.Null(pessoa.Id);
            Assert.Null(pessoa.Nome);
            Assert.Null(pessoa.Email);
            Assert.Null(pessoa.Senha);
        }

        [Fact]
        public void Pessoa_ValidProperties_PassesValidation()
        {
            // Arrange
            var pessoa = new Pessoa("João Silva", "joao@email.com", "senha123");
            var context = new ValidationContext(pessoa, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(pessoa, context, validationResults, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void Pessoa_InvalidProperties_FailsValidation()
        {
            // Arrange
            var pessoa = new Pessoa(null, null, "senha123");
            var context = new ValidationContext(pessoa, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(pessoa, context, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(pessoa.Nome)));
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(pessoa.Email)));
        }

        [Fact]
        public void Pessoa_EmptySenha_IsAllowed()
        {
            // Arrange
            var pessoa = new Pessoa("João Silva", "joao@email.com", string.Empty);
            var context = new ValidationContext(pessoa, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(pessoa, context, validationResults, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }

}
