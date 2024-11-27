using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using Moq;
using trayprojeto45;
using trayprojeto45.Endpoint;

namespace TestTray.TestEndpoint
{


    public class ComprasTests
    {
        private readonly Mock<DbSet<Compra>> _mockSet;
        private readonly Mock<trayprojeto45DbContext> _mockContext;

        public ComprasTests()
        {
            // Mock do DbSet
            _mockSet = new Mock<DbSet<Compra>>();
            _mockContext = new Mock<trayprojeto45DbContext>();

            _mockContext.Setup(c => c.Compra).Returns(_mockSet.Object);
        }

        [Fact]
        public async Task Get_Compras_ReturnsFilteredResults()
        {
            // Arrange
            var compras = new List<Compra>
        {
            new Compra { Produto = "Produto1", Preco = 100, Cidade = "Cidade1", Estado = "Estado1" },
            new Compra { Produto = "Produto2", Preco = 200, Cidade = "Cidade2", Estado = "Estado2" }
        }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Compra>>();
            mockDbSet.As<IQueryable<Compra>>().Setup(m => m.Provider).Returns(compras.Provider);
            mockDbSet.As<IQueryable<Compra>>().Setup(m => m.Expression).Returns(compras.Expression);
            mockDbSet.As<IQueryable<Compra>>().Setup(m => m.ElementType).Returns(compras.ElementType);
            mockDbSet.As<IQueryable<Compra>>().Setup(m => m.GetEnumerator()).Returns(compras.GetEnumerator());

            _mockContext.Setup(c => c.Compra).Returns(mockDbSet.Object);

            var requestMock = new Mock<HttpRequest>();
            requestMock.Setup(r => r.Query["produto"]).Returns("Produto1");

            var responseMock = new Mock<HttpResponse>();
            responseMock.SetupProperty(r => r.StatusCode);

            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(c => c.Request).Returns(requestMock.Object);
            contextMock.Setup(c => c.Response).Returns(responseMock.Object);
            contextMock.Setup(c => c.RequestServices.GetService(typeof(trayprojeto45DbContext)))
                       .Returns(_mockContext.Object);
        }

        // Outros testes podem seguir aqui para validações de erros ou caminhos não esperados.
    }

}
