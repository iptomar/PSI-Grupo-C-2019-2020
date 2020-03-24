from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import time

drive = webdriver.Firefox(executable_path="/usr/bin/geckodriver")

drive.set_page_load_timeout(10)
drive.get("http://google.com")
drive.find_element_by_xpath("q").send_keys("Automation Step By Step")
drive.find_element_by_name("q").send_keys(Keys.ENTER)
time.sleep(4)
drive.quit()