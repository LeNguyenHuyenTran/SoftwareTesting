using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace _93_Tran_N1_TestChucNangTrangWeb
{
    [TestClass]
    public class UnitTest1
    {
        string actual;
        string user;
        string pass;
        string expected;
        private WebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://bountysneakers.com/");
        }

        [TestMethod]
        public void TestLogin_Testcase01_PassNull()
        {
            user = "chonthanh13@gmail.com";
            pass = "";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            IWebElement tbao = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[1]/p"));
            actual = tbao.Text;
            expected = "Vui lòng nhập Mật khẩu";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestLogin_Testcase02_EmailNull()
        {
            user = "";
            pass = "tran@123";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            expected = "Please fill out this field";
            IAlert alert = null;
            try
            {
                alert = driver.SwitchTo().Alert();
                actual = alert.Text;
                Assert.AreEqual(expected, actual);
            }
            catch (NoAlertPresentException)
            {

            }
            driver.Quit();
        }
        [TestMethod]
        public void TestLogin_Testcase03_EmailAndPassNull()
        {
            user = "";
            pass = "";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            expected = "Please fill out this field";
            IAlert alert = null;
            try
            {
                alert = driver.SwitchTo().Alert();
                actual = alert.Text;
                Assert.AreEqual(expected, actual);
            }
            catch (NoAlertPresentException)
            {

            }
            driver.Quit();
        }
        [TestMethod]
        public void TestLogin_Testcase04_EMailWrongFormat()
        {
            user = "chonthanh13@gmail.com";
            pass = "dfkjfhhhhh";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            expected = "Please include an '@' int the email address. 'chonthanh13' is missing an '@'.";
            IAlert alert = null;
            try
            {
                alert = driver.SwitchTo().Alert();
                actual = alert.Text;
                Assert.AreEqual(expected, actual);
            }
            catch (NoAlertPresentException)
            {
                // Khong co ngoai le nao
            }
            driver.Quit();
        }
        [TestMethod]
        public void TestLogin_Testcase05_PassWrong()
        {
            user = "chonthanh13@gmail.com";
            pass = "dfkjfhhhhh";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            IWebElement tbao = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[1]/p"));
            actual = tbao.Text;
            expected = "Thông tin đăng nhập không chính xác.";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }

        [TestMethod]
        public void TestLogin_Testcase06_EmailThieu()
        {
            user = "chonthanh13@";
            pass = "dfkjfhhhhh";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            expected = "Please enter a part following '@'. 'chonthanh13@' is incomplete.";
            IAlert alert = null;
            try
            {
                alert = driver.SwitchTo().Alert();
                actual = alert.Text;
                Assert.AreEqual(expected, actual);
            }
            catch (NoAlertPresentException)
            {
                // Khong co ngoai le nao
            }
            driver.Quit();
        }
        [TestMethod]
        public void TestLogin_Testcase07_LoginSuccess()
        {
            user = "chonthanh13@gmail.com";
            pass = "tran@123";
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys(user);
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys(pass);
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            IWebElement tbao = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[1]/div/p/span"));
            actual = tbao.Text;
            expected = "Tran Le Nguyen Huyen";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestSearch_Testcase01_SearchNoKeyword()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys("chonthanh13@gmail.com");
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys("tran@123");
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            IWebElement txtTimKiem = driver.FindElement(By.Name("query"));
            txtTimKiem.SendKeys("");
            IWebElement search = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[2]/div[2]/form/input[2]"));
            search.Click();
            actual = driver.Title;
            expected = "Tìm kiếm Bounty Sneakers";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestSearch_Testcase02_DontHaveResult()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys("chonthanh13@gmail.com");
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys("tran@123");
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            IWebElement txtTimKiem = driver.FindElement(By.Name("query"));
            txtTimKiem.SendKeys("krdjshgvg");
            IWebElement search = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[2]/div[2]/form/input[2]"));
            search.Click();
            IWebElement kq = driver.FindElement(By.XPath("/html/body/section/div/div/div/div"));
            actual = kq.Text;
            expected = "Không tìm thấy bất kỳ kết quả với từ khóa: \"krdjshgvg\"";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestSearch_Testcase03_HaveResult()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[1]/a"));
            c.Click();
            IWebElement nhapUser = driver.FindElement(By.Name("email"));
            nhapUser.SendKeys("chonthanh13@gmail.com");
            IWebElement nhapPass = driver.FindElement(By.Id("customer_password"));
            nhapPass.SendKeys("tran@123");
            IWebElement btLogin = driver.FindElement(By.XPath("//*[@id=\"customer_login\"]/div[3]/button"));
            btLogin.Click();
            IWebElement txtTimKiem = driver.FindElement(By.Name("query"));
            txtTimKiem.SendKeys("adidas");
            IWebElement search = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[2]/div[2]/form/input[2]"));
            search.Click();
            IWebElement kq = driver.FindElement(By.XPath("/html/body/section/div/div/div/div[2]/div/div/ul/li[1]/span"));
            actual = kq.Text;
            expected = "1";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestRegister_Testcase01_LastNameNull()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[2]/a"));
            c.Click();
            IWebElement LastName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[1]/div/input"));
            LastName.SendKeys("");
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[2]/div/input"));
            FirstName.SendKeys("Le Nguyen Huyen");
            IWebElement Email = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[3]/div/input"));
            Email.SendKeys("2151013101Tran@ou.edu.vn");
            IWebElement PhoneNumber = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[4]/div/input"));
            PhoneNumber.SendKeys("0332218840");
            IWebElement Password = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[5]/div/input"));
            Password.SendKeys("0332218840");
            IWebElement Register = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[6]/div/button"));
            Register.Click();
            expected = "Please fill out this field";
            IAlert alert = null;
            try
            {
                alert = driver.SwitchTo().Alert();
                actual = alert.Text;
                Assert.AreEqual(expected, actual);
            }
            catch (NoAlertPresentException)
            {
                // Khong co ngoai le nao
            }
            driver.Quit();
        }
        [TestMethod]
        public void TestRegister_Testcase02_WrongFormat()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[2]/a"));
            c.Click();
            IWebElement LastName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[1]/div/input"));
            LastName.SendKeys("Tran");
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[2]/div/input"));
            FirstName.SendKeys("Le Nguyen Huyen");
            IWebElement Email = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[3]/div/input"));
            Email.SendKeys("2151013101Tran");
            IWebElement PhoneNumber = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[4]/div/input"));
            PhoneNumber.SendKeys("0332218840");
            IWebElement Password = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[5]/div/input"));
            Password.SendKeys("sdfghjjhgfds");
            IWebElement Register = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[6]/div/button"));
            Register.Click();
            IWebElement alert = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div[1]/p"));
            actual = alert.Text;
            expected = "Email không đúng định dạng";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestRegister_Testcase03_EmailAlready()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[2]/a"));
            c.Click();
            IWebElement LastName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[1]/div/input"));
            LastName.SendKeys("Tran");
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[2]/div/input"));
            FirstName.SendKeys("Le Nguyen Huyen");
            IWebElement Email = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[3]/div/input"));
            Email.SendKeys("chonthanh13@gmail.com");
            IWebElement PhoneNumber = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[4]/div/input"));
            PhoneNumber.SendKeys("0346864350");
            IWebElement Password = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[5]/div/input"));
            Password.SendKeys("tran@1234");
            IWebElement Register = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[6]/div/button"));
            Register.Click();
            IWebElement alert = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div[1]/p"));
            actual = alert.Text;
            expected = "Email đã tồn tại.";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
        [TestMethod]
        public void TestRegister_Testcase04_PhoneNumberAlready()
        {
            IWebElement c = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div[3]/div/div[1]/ul/li[2]/a"));
            c.Click();
            IWebElement LastName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[1]/div/input"));
            LastName.SendKeys("Tran");
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[2]/div/input"));
            FirstName.SendKeys("Le Nguyen Huyen");
            IWebElement Email = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[3]/div/input"));
            Email.SendKeys("2151013101tran@ou.edu.vn");
            IWebElement PhoneNumber = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[4]/div/input"));
            PhoneNumber.SendKeys("0346864350");
            IWebElement Password = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[5]/div/input"));
            Password.SendKeys("tran@1234");
            IWebElement Register = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div/div[6]/div/button"));
            Register.Click();
            IWebElement alert = driver.FindElement(By.XPath("//*[@id=\"customer_register\"]/div[1]/p"));
            actual = alert.Text;
            expected = "Số điện thoại đã tồn tại.";
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }
    }
}
