using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace TestProject
{
    public class IngresarUsuarioBloqueado
    {
        [Fact]
        public void UsuarioBloqueado()
        {


            IWebDriver driver = new ChromeDriver();
            try
            {

                driver.Url = "https://www.saucedemo.com/";

                string User = "locked_out_user";
                string Pass = "secret_sauce";

                IWebElement usuario = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input"));
                usuario.SendKeys(User);


                IWebElement pass = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input"));
                pass.SendKeys(Pass);


                IWebElement btnIngresar = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/input"));
                btnIngresar.Click();



                Thread.Sleep(5000);
                IWebElement elemento = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div/div/form/div[3]/h3"));

                string textoDelElemento = elemento.Text;



                Assert.Equal("Epic sadface: Sorry, this user has been locked out.", textoDelElemento);


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
