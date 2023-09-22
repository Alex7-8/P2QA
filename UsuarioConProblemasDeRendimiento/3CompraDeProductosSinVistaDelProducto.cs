using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace TestProject
{
    public class IngresarAlSistemaCompraProductos
    {
        [Fact]
        public void ListadeProductos()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {




                driver.Url = "https://www.saucedemo.com/";

                IWebElement usuario = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input"));
                usuario.SendKeys("performance_glitch_user");


                IWebElement pass = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input"));
                pass.SendKeys("secret_sauce");


                IWebElement btnIngresar = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar.Click();
                Thread.Sleep(5000);




                IWebElement btnAgregarProducto1 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[3]/div[2]/div[2]/button"));
                btnAgregarProducto1.Click();
                Thread.Sleep(2000);
                IWebElement btnAgregarProducto2 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[4]/div[2]/div[2]/button"));
                btnAgregarProducto2.Click();
                Thread.Sleep(2000);
                IWebElement btnAgregarProducto3 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[2]/div[2]/div[2]/button"));
                btnAgregarProducto3.Click();
                Thread.Sleep(2000);
                IWebElement btnAgregarProducto4 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[6]/div[2]/div[2]/button"));
                btnAgregarProducto4.Click();
                Thread.Sleep(2000);



                IWebElement elementoCarrito = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
                string textoDelElemento = elementoCarrito.Text;

                if (textoDelElemento == "4")
                {
                    IWebElement btnCarrito = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
                    btnCarrito.Click();
                    Thread.Sleep(2000);

                    By btnCheckOutV = By.XPath("/html/body/div/div/div/div[2]/div/div[2]/button[2]");
                    Thread.Sleep(2000);
                    var elementos = driver.FindElements(btnCheckOutV);
                    if (elementos.Count > 0)
                    {

                        IWebElement btnCheckOut = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/button[2]"));
                        btnCheckOut.Click();
                        Thread.Sleep(2000);

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

                        IWebElement elemento = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div"));
                        textoDelElemento = elemento.Text;

                        IWebElement btnRegresar3 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/button"));
                        btnRegresar3.Click();



                        if (textoDelElemento == "Your order has been dispatched, and will arrive just as fast as the pony can get there!")
                        {


                            Assert.True(true);
                        }
                        else
                        {
                            Assert.False(true);
                        }
                    }
                    else
                    {
                        driver.Quit();
                        Assert.Fail("Existe un Bug que deja en blanco el menu de Checkout");
                    }
                }
                else
                {
                    driver.Quit();
                    Assert.Fail("Existe un Bug que no permite añadir mas productos al carrito");



                }



                driver.Quit();

            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(e.Message);
                driver.Quit();

            }





        }


    }
}
