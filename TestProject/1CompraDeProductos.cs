using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace TestProject
{
    public class IngresarAlSistemaCompra
    {
        [Fact]
        public void Carrito()
        {
            IWebDriver driver = new ChromeDriver();

            try
            { 

                driver.Url = "https://www.saucedemo.com/";

                IWebElement usuario = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input"));
                usuario.SendKeys("standard_user");


                IWebElement pass = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input"));
                pass.SendKeys("secret_sauce");


                IWebElement btnIngresar = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar.Click();

                Thread.Sleep(5000);

                IWebElement btnVerProducto = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[1]/div[2]/div[1]/a/div"));
                btnVerProducto.Click();

                Thread.Sleep(5000);

                IWebElement btnAgregarProductos = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div[2]/button"));
                btnAgregarProductos.Click();
                                                                          
                Thread.Sleep(2000);

                IWebElement btnRegresar = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div/button"));
                btnRegresar.Click();

                Thread.Sleep(5000);
                IWebElement btnVerProductos = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[4]/div[2]/div[1]/a/div"));
                btnVerProductos.Click();

                Thread.Sleep(5000);
                IWebElement btnAgregarProductos2 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div[2]/button"));
                btnAgregarProductos2.Click();
                Thread.Sleep(2000);
                IWebElement btnRegresar2 = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div/button"));
                btnRegresar2.Click();
                Thread.Sleep(5000);

                IWebElement btnCarrito = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
                btnCarrito.Click();
                Thread.Sleep(5000);
                IWebElement btnCheckOut = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/button[2]"));
                btnCheckOut.Click();
                Thread.Sleep(5000);

                IWebElement Nombre = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[1]/input"));
                IWebElement Apellido = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[2]/input"));
                IWebElement CodigoPostal = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[3]/input"));
                Nombre.SendKeys("Alexander");
                Apellido.SendKeys("Orellana");
                CodigoPostal.SendKeys("12345");

                Thread.Sleep(5000);

                IWebElement btnContinuar = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[2]/input"));
                btnContinuar.Click();

                Thread.Sleep(5000);

                IWebElement btnFinalizar = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[9]/button[2]"));
                btnFinalizar.Click();
                Thread.Sleep(2000);

                IWebElement btnRegresar3 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[9]/button[2]"));
                btnRegresar3.Click();

                Thread.Sleep(2000);

                IWebElement elemento = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div"));
                string textoDelElemento = elemento.Text;

              

                Assert.Equal("Your order has been dispatched, and will arrive just as fast as the pony can get there!", textoDelElemento);



              



                driver.Quit();

            }
            catch (NoSuchElementException e)
            {
                Assert.False(false);
                Console.WriteLine(e.Message);
                driver.Quit();

            }


            


        }


    }
}
