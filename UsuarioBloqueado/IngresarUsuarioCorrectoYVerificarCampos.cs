using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace TestProject
{
    public class IngresarUsuarioCorrectoYVerificarCampos
    {
        [Fact]
        public void VerificarCamposDeUsuarioYContraseniaRequerido()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {



                driver.Url = "https://www.saucedemo.com/";
                string User = "standard_user";
                string Pass = "secret_sauce";

                IWebElement btnIngresar = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar.Click();



                Thread.Sleep(2000);
                IWebElement elemento = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[3]/h3"));

                string textoDelElemento = elemento.Text;



                if (textoDelElemento == "Epic sadface: Username is required") 
                {
                    IWebElement usuario = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input"));
                    usuario.SendKeys(User);

                }
                IWebElement btnIngresar2 = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar2.Click();


                Thread.Sleep(2000);
                IWebElement elemento2 = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[3]/h3"));

                textoDelElemento = elemento2.Text;

                if (textoDelElemento == "Epic sadface: Password is required")
                {
                    IWebElement pass = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input"));
                    pass.SendKeys(Pass);
                }
                Thread.Sleep(2000);
                IWebElement btnIngresar3 = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar3.Click();

                Thread.Sleep(2000);
                IWebElement elemento3 = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[2]/div"));
                textoDelElemento = elemento3.Text;






                if (textoDelElemento == "Swag Labs")
                {


                    Assert.True(true);
                }
                else
                {
                    Assert.False(true);
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
