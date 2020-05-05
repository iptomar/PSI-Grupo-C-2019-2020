from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import time

drive = webdriver.Chrome(executable_path=r"C:\Users\night\PycharmProjects\selenium\venv\Lib\site-packages\selenium\webdriver\chrome\chromedriver.exe")

drive.set_page_load_timeout(10)

drive.get("http://www.google.com")

drive.find_element_by_name("q").send_keys("r", (Keys.ENTER))



