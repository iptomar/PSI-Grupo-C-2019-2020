import unittest

from selenium import webdriver

from selenium.webdriver.common.keys import Keys


class Ram(unittest.TestCase):

    def setUp(self):
        self.driver = webdriver.Chrome(executable_path=r"C:\Users\night\PycharmProjects\selenium\venv\Lib\site-packages\selenium\webdriver\chrome\chromedriver.exe")

    def test_search_LogIN(self):
        driver = self.driver
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", (Keys.TAB), "a", (Keys.ENTER))
        try:
            assert "Invalid login attempt." not in driver.page_source
            print((f"\nTest LogIn OK!"))
        except Exception as err:
            print (f"\nTest LogIn Failure!!!")

    def test_search_DownloadAPP(self):
        driver = self.driver
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", (Keys.TAB), "a", (Keys.ENTER))
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        driver.find_element_by_xpath("//div[@class='card sale-diffrence-border']").click()
        #driver.find_element_by_class_name("line-chart-row-title")
        #driver.find_element_by_xpath("//div[@class='line-chart-row-title']").click()
        try:
            driver.find_element_by_class_name("AHFaub")
            print (f"\nTest DownloadAPP OK!")
        except Exception as err:
            print (f"\nTest DownloadAPP Failure!!!")

    def test_search_Roteiros(self):
        driver = self.driver
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", (Keys.TAB), "a", (Keys.ENTER))
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        driver.find_element_by_xpath("//div[@class='card card-border-amarelo']").click()
        try:
            driver.find_element_by_xpath("//a[@class='btn btn-primary']")
            print(f"\nTest Roteiros OK!")
        except Exception as err:
            print(f"\nTest Roteiros Failure!!!")

    def tearDown(self):
        self.driver.quit()


if __name__ == '__main__':
    unittest.main()
