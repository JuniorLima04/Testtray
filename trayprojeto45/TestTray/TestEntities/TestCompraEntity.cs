using System.ComponentModel.DataAnnotations;
using trayprojeto45;
using Xunit;


namespace TestTray.TestEntities
{

    public class CompraTests
    {
        [Fact]
        public void Compra_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var produto = "Produto Teste";
            var preco = 100.50m;
            var email = "teste@teste.com";
            var cidade = "São Paulo";
            var estado = "SP";
            var complemento = "Apartamento 101";

            // Act
            var compra = new Compra(produto, preco, email, cidade, estado, complemento);

            // Assert
            Assert.Equal(produto, compra.Produto);
            Assert.Equal(preco, compra.Preco);
            Assert.Equal(email, compra.Email);
            Assert.Equal(cidade, compra.Cidade);
            Assert.Equal(estado, compra.Estado);
            Assert.Equal(complemento, compra.Complemento);
        }

        [Fact]
        public void Compra_DefaultConstructor_InitializesPropertiesWithDefaults()
        {
            // Act
            var compra = new Compra();

            // Assert
            Assert.Null(compra.Id);
            Assert.Null(compra.Produto);
            Assert.Equal(0m, compra.Preco);
            Assert.Null(compra.Email);
            Assert.Null(compra.Cidade);
            Assert.Null(compra.Estado);
            Assert.Null(compra.Complemento);
        }

        [Fact]
        public void Compra_ValidProperties_PassesValidation()
        {
            // Arrange
            var compra = new Compra
            {
                Produto = "Produto Teste",
                Preco = 100.50m,
                Email = "teste@teste.com",
                Cidade = "São Paulo",
                Estado = "SP",
                Complemento = "Apartamento 101"
            };

            var context = new ValidationContext(compra, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(compra, context, validationResults, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void Compra_InvalidProperties_FailsValidation()
        {
            // Arrange
            var compra = new Compra
            {
                Produto = null, // Required
                Preco = 0m,     // Valid, mas vamos testar sem outro campo requerido
                Email = null,   // Required
                Cidade = null   // Required
            };

            var context = new ValidationContext(compra, null, null);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(compra, context, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(compra.Produto)));
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(compra.Email)));

        }
    }
}