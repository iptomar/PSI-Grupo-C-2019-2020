import unittest

from selenium import webdriver

from selenium.webdriver.common.keys import Keys


class RAM(unittest.TestCase):

    def setUp(self):
        self.driver = webdriver.Firefox(executable_path="/usr/bin/geckodriver")

    def test_search_in_python_google(self):
        driver = self.driver
        driver.get("https://ramtomar.azurewebsites.net")
        self.assertIn("Google", driver.title)
        elem = driver.find_element_by_name("q")
        elem.send_keys("Automation Step By Step")
        elem.send_keys(Keys.RETURN)
        assert "No result found" not in driver.page_source

    def tearDown(self):
        self.driver.quit()


if __name__ == "__main__":
    unittest.main()
