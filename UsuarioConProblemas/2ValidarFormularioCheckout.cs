using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace TestProject
{
    public class IngresarAlSistemaCompraValidarCheckOut
    {
        [Fact]
        public void ValidarCheckOut()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                string Nombre = "Alex";
                string Apellido = "Orellana";
                string CodigoPostal = "12345";




                driver.Url = "https://www.saucedemo.com/";

                IWebElement usuario = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input"));
                usuario.SendKeys("problem_user");


                IWebElement pass = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input"));
                pass.SendKeys("secret_sauce");


                IWebElement btnIngresar = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar.Click();

                Thread.Sleep(2000);




                IWebElement btnAgregarProductos = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[1]/div[2]/div[2]/button"));
                btnAgregarProductos.Click();

                Thread.Sleep(2000);



                IWebElement btnCarrito = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
                btnCarrito.Click();
                Thread.Sleep(2000);
                By btnCheckOutV = By.XPath("/html/body/div/div/div/div[2]/div/div[2]/button[2]");
                Thread.Sleep(5000);


                IWebElement elementoCarrito = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a"));
                string textoDelElemento = elementoCarrito.Text;

                int numeroEntero = int.Parse(textoDelElemento);

                if (numeroEntero >= 1)
                {
                    var elementos = driver.FindElements(btnCheckOutV);
                    if (elementos.Count > 0)
                    {
                        IWebElement btnCheckOut = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/button[2]"));
                        btnCheckOut.Click();
                        Thread.Sleep(2000);
                        IWebElement btnContinuar = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[2]/input"));
                        btnContinuar.Click();

                        IWebElement CampoValidar = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[4]/h3"));
                        string textoDelElementoCampo = CampoValidar.Text;


                        if (textoDelElementoCampo == "Error: First Name is required")
                        {
                            IWebElement nombre = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[1]/input"));
                            nombre.SendKeys(Nombre);

                        }
                        Thread.Sleep(2000);
                        IWebElement btnContinuar2 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[2]/input"));
                        btnContinuar2.Click();

                        IWebElement CampoValidar2 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[4]/h3"));
                        textoDelElementoCampo = CampoValidar2.Text;

                        if (textoDelElementoCampo == "Error: Last Name is required")
                        {
                            IWebElement apellido = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[2]/input"));
                            Console.WriteLine("El campo es requerido");
                            apellido.SendKeys(Apellido);

                        }
                        Thread.Sleep(2000);
                        IWebElement btnContinuar3 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[2]/input"));
                        btnContinuar3.Click();
                        IWebElement CampoValidar3 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[4]/h3"));
                        textoDelElementoCampo = CampoValidar3.Text;

                        if (textoDelElementoCampo == "Error: Postal Code is required")
                        {
                            IWebElement codigoPostal = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[3]/input"));
                            Console.WriteLine("El campo es requerido");
                            codigoPostal.SendKeys(CodigoPostal);
                        }



                        IWebElement ValidarTexto = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[1]/div[1]/input"));
                        Thread.Sleep(2000);



                       string ValidartextoDelElementoCampo = ValidarTexto.GetAttribute("value");
                        if (ValidartextoDelElementoCampo == Nombre)
                        {

                            Thread.Sleep(2000);
                            IWebElement btnContinuar4 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/form/div[2]/input"));
                            btnContinuar4.Click();


                            Thread.Sleep(2000);

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
                                driver.Quit();
                            }
                            else
                            {
                                driver.Quit();
                                Assert.True(false);
                            }
                        }
                        else
                        {
                            driver.Quit();
                            Assert.Fail("Existe un Bug que no permite agregar el campo de apellido y de codigo postal");
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
                    Assert.Fail("Existe un Bug que no permite añadir mas pruductos al carrito");
                }













                }
            catch (NoSuchElementException e)
            {
                driver.Quit();
                Assert.Fail(e.Message);
                

            }


            


        }


    }
}
