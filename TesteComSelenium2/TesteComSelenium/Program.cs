using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

/*
 * instalar os pacotes:
 * install-package Selenium.WebDriver
 * install-package Selenium.WebDriver.ChromeDriver
 */
namespace TesteComSelenium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //incializa Webdriver e abre o navegador
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:5173");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://localhost:5173/cad");
            Thread.Sleep(1000);
            void PreencheFormulario(int i)
            {
Thread.Sleep(500);

                //acessar o campo ra atraves do ID
                IWebElement camponome = driver.FindElement(By.Id("nome"));
                //limpar o campo
                camponome.Clear();
                //preencher o campo com o valor
                camponome.SendKeys("nometeste");
                Thread.Sleep(500);

                IWebElement campoemail = driver.FindElement(By.Id("email"));
                campoemail.Clear();
                campoemail.SendKeys($"Teste@gmail.com{i}");
                Thread.Sleep(500);

                IWebElement camposenha = driver.FindElement(By.Id("senha"));
                camposenha.Clear();
                camposenha.SendKeys($"teste senha{i}");
                Thread.Sleep(500);

                driver.Navigate().GoToUrl("http://localhost:5173/com");

                IWebElement botaoCompra = driver.FindElement(By.Id("btnComprar_0"));

                botaoCompra.Click();
                //gera valor aleatorio para o RA (chave primária)
                

                //acessar o campo ra atraves do ID
                IWebElement campoEmail = driver.FindElement(By.Id("email"));
                //limpar o campo
                campoEmail.Clear();
                //preencher o campo com o valor
                campoEmail.SendKeys("teste@email.com");
                Thread.Sleep(500);

                IWebElement campoendereco = driver.FindElement(By.Id("endereco"));
                campoendereco.Clear();
                campoendereco.SendKeys($"Teste Endereco{i}");
                Thread.Sleep(500);

                IWebElement campocidade = driver.FindElement(By.Id("cidade"));
                campocidade.Clear();
                campocidade.SendKeys($"teste cidade{i}");
                Thread.Sleep(500);

                 IWebElement campoestado = driver.FindElement(By.Id("estado"));
                campoestado.Clear();
                campoestado.SendKeys($"teste estado{i}");
                Thread.Sleep(500);

                 IWebElement campocomplemento = driver.FindElement(By.Id("complemento"));
                campocomplemento.Clear();
                campocomplemento.SendKeys($"teste complemento{i}");
                Thread.Sleep(500);

                   //acessa o botao OK do modal de sucesso
                IWebElement botaoOK = driver.FindElement(By.Id("btnFinaliza"));
                //executa o click no botao OK
                botaoOK.Click();
                Thread.Sleep(500);

                driver.Navigate().GoToUrl("http://localhost:5173/cart/Nike");

                Thread.Sleep(900);

                driver.Navigate().GoToUrl("http://localhost:5173");

                


                // //acessa o botao de gravar
                // IWebElement botaoGravar = driver.FindElement(By.CssSelector("#navbar > ul > li:nth-child(2) > a"));
                // //executa o click
                // botaoGravar.Click();

                // //aguarda 3 segundos para que a requisição seja concluida no backend
                // Thread.Sleep(3000);

                // //acessa o botao OK do modal de sucesso
                // IWebElement botaoOK = driver.FindElement(By.CssSelector("button.swal2-confirm"));
                // //executa o click no botao OK
                // botaoOK.Click();
            }

            //executa o teste N vezes
            for(int i = 0; i <1;i++)
            {
                PreencheFormulario(i);
            }




        }
    }
}
