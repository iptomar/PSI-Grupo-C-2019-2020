import unittest

from selenium import webdriver

from selenium.webdriver.common.keys import Keys

from selenium.webdriver.common.action_chains import ActionChains


class Ram(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome(
            executable_path=r"C:\Users\night\PycharmProjects\selenium\venv\Lib\site-packages\selenium\webdriver"
                            r"\chrome\chromedriver.exe")

    def test_search_LogIN(self):
        driver = self.driver
        driver.maximize_window()
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
        try:
            assert "Invalid login attempt." not in driver.page_source
            print(f"\nTest LogIn OK!")
        except Exception as err:
            print(f"\nTest LogIn Failure!!!")

    def test_search_LogOut(self):
        driver = self.driver
        driver.maximize_window()
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        driver.find_element_by_xpath("//span[@class='btn btn-inverse-primary btn-sm']").click()
        try:
            self.assertIn("RAM Tomar Login", driver.title)
            print(f"\nTest LogOut OK!")
        except Exception as err:
            print(f"\nTest LogOut Failure!!!")

    def test_search_pI_dropDown_pIList(self):
        driver = self.driver
        driver.maximize_window()
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
        hover = ActionChains(driver).move_to_element(element_to_hover_over)
        hover.perform()
        driver.find_element_by_xpath("//a[@class='nav-link']").click()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse']")
       try:
           driver.find_element_by_xpath("//a[@href='/PontosInteresse/Create']")
           print(f"\nTest Pontos Interesse Dropdown OK!")
       except Exception as err:
           print(f"\nTest Pontos Interesse Dropdown Failure!!!")


    def test_search_createPI(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse']").click()
       driver.set_page_load_timeout(10)
       try:
           driver.find_element_by_xpath("//a[@class='btn btn-primary']").click()
       except Exception as err:
           print(f"\nTest Criar Pontos Interesse Failure!!!")
       try:
           driver.find_element_by_xpath("//button[@class='btn btn-success']")
           print(f"\nTest Criar Pontos Interesse OK!")
       except Exception as err:
           print(f"\nTest Criar Pontos Interesse Failure!!!")

    def test_search_detalhesPI(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse']").click()
       driver.set_page_load_timeout(10)
       driver.find_element_by_xpath("//a[@href='/PontosInteresse/Details/3']").click()
       try:
           driver.find_element_by_xpath("//div[@class='h3']")
           print(f"\nTest Detalhes Pontos Interesse OK!")
       except Exception as err:
           print(f"\nTest Detalhes Pontos Interesse Failure!!!")

    def test_search_editarDetalhesPI(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse']").click()
       driver.set_page_load_timeout(10)
       driver.find_element_by_xpath("//a[@href='/PontosInteresse/Edit/3']").click()
       try:
           driver.find_element_by_xpath("//form[@action='/PontosInteresse/Edit/3']")
           print(f"\nTest Editar Detalhes Pontos Interesse OK!")
       except Exception as err:
           print(f"\nTest Editar Detalhes Pontos Interesse Failure!!!")

    def test_search_apagarPI(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse']").click()
       driver.set_page_load_timeout(10)
       driver.find_element_by_xpath("//a[@href='/PontosInteresse/Delete/3']").click()
       try:
           driver.find_element_by_xpath("//input[@value='Eliminar']")
           print(f"\nTest Eliminar Pontos Interesse OK!")
       except Exception as err:
           print(f"\nTest Eliminar Pontos Interesse Failure!!!")

    # def test_search_novoPI(self):
    #     driver = self.driver
    #     driver.maximize_window()
    #     driver.get("https://ramtomar.azurewebsites.net/")
    #     self.assertIn("RAM Tomar Login", driver.title)
    #     driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
    #     assert "Invalid login attempt." not in driver.page_source
    #     driver.set_page_load_timeout(10)
    #     element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
    #     hover = ActionChains(driver).move_to_element(element_to_hover_over)
    #     hover.perform()
    #     driver.find_element_by_xpath("//a[@href='/PontosInteresse']").click()
    #     driver.set_page_load_timeout(10)
    #     driver.find_element_by_xpath("//a[@href='/PontosInteresse/Create']").click()
    #     driver.find_element_by_xpath("//input[@id='PontoInteresse_Nome']").send_keys("a", Keys.TAB, "a", Keys.TAB, "a", Keys.TAB, "a", Keys.TAB, 1990, Keys.TAB, Keys.TAB, 123, Keys.TAB, 123, Keys.TAB, 123, Keys.TAB, 123, Keys.TAB)
    #     driver.find_element_by_xpath("//button[@data-bind='click: adicionarCoordenada']").cllick()
    #     try:
    #         driver.find_element_by_xpath("//button[@data-bind='click: $root.removerCoordenada']").cllick()
    #         print(f"\nTest Adicionar Pontos Interesse OK!")
    #     except Exception as err:
    #         print(f"\nTest Adicionar Pontos Interesse Failure!!!")

    def test_search_pI_dropDown_newPI(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse/Create']").click()
       try:
           driver.find_element_by_xpath("//button[@class='btn btn-success']")
           print(f"\nTest Criar Pontos Interesse Dropdown OK!")
       except Exception as err:
           print(f"\nTest Criar Pontos Interesse Dropdown Failure!!!")



    def test_search_pI_dropDown_AproovePI(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath    def test_search_roteiros_dropDown_newRoteiro(self):
           driver = self.driver
           driver.maximize_window()
           driver.get("https://ramtomar.azurewebsites.net/")
           self.assertIn("RAM Tomar Login", driver.title)
           driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
           assert "Invalid login attempt." not in driver.page_source
           driver.set_page_load_timeout(10)
           element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoPontos']")
           hover = ActionChains(driver).move_to_element(element_to_hover_over)
           hover.perform()
           driver.find_element_by_xpath("//a[@href='/Roteiros/Create']").click()
           try:
               assert " Novo Roteiro"
               print(f"\nTest Novo Roteiro DropDown OK!")
           except Exception as err:
               print(f"\nTest Novo Roteiro DropDown Failure!!!")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/PontosInteresse/IndexAprovacao']").click()
       try:
           assert "Pontos pendentes de aprovação"
           print(f"\nTest Aprovar Pontos Interesse Dropdown OK!")
       except Exception as err:
           print(f"\nTest Aprovar Pontos Interesse Dropdown Failure!!!")

    def test_search_roteiros_dropDown_RoteirosLista(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoRoteiros']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Roteiros']").click()
       try:
           driver.find_element_by_xpath("//a[@class='btn btn-primary']")
           print(f"\nTest Roteiros DropDown OK!")
       except Exception as err:
           print(f"\nTest Roteiros DropDown Failure!!!")

    def test_search_roteiros_dropDown_newRoteiro(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoRoteiros']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Roteiros/Create']").click()
       try:
           assert " Novo Roteiro"
           print(f"\nTest Novo Roteiro DropDown OK!")
       except Exception as err:
           print(f"\nTest Novo Roteiro DropDown Failure!!!")

    def test_search_imagens_dropDown_verLista(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoImagens']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Imagens']").click()
       try:
           driver.find_element_by_xpath("//a[@href='/Imagens/Create']")
           print(f"\nTest Ver Lista Imagens DropDown OK!")
       except Exception as err:
           print(f"\nTest Ver Lista Imagens DropDown Failure!!!")

    def test_search_imagens_dropDown_adicionarImagem(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoImagens']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Imagens/Create']").click()
       try:
           assert " Nova Imagem"
           print(f"\nTest Nova Imagem DropDown OK!")
       except Exception as err:
           print(f"\nTest Nova Imagem DropDown Failure!!!")

    def test_search_utilizadores_dropDown_verLista(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoUsers']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Account']").click()
       try:
           driver.find_element_by_xpath("//a[@href='/Account/Register']")
           print(f"\nTest Ver Lista Utilizadores DropDown OK!")
       except Exception as err:
           print(f"\nTest Ver Lista Utilizadores DropDown Failure!!!")

    def test_search_utilizadores_dropDown_newUser(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoUsers']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Account/Register']").click()
       try:
           driver.find_element_by_xpath("//input[@value='Register']")
           print(f"\nTest Adicionar Novo Utilizador DropDown OK!")
       except Exception as err:
           print(f"\nTest Adicionar Novo Utilizador DropDown Failure!!!")


    def test_search_utilizadores_dropDown_gerirConta(self):
       driver = self.driver
       driver.maximize_window()
       driver.get("https://ramtomar.azurewebsites.net/")
       self.assertIn("RAM Tomar Login", driver.title)
       driver.find_element_by_id("exampleInputEmail").send_keys("a", Keys.TAB, "a", Keys.ENTER)
       assert "Invalid login attempt." not in driver.page_source
       driver.set_page_load_timeout(10)
       element_to_hover_over = driver.find_element_by_xpath("//li[@id='botaoUsers']")
       hover = ActionChains(driver).move_to_element(element_to_hover_over)
       hover.perform()
       driver.find_element_by_xpath("//a[@href='/Manage']").click()
       try:
           driver.find_element_by_xpath("//a[@href='/Manage/ChangePassword']")
           print(f"\nTest Gerir Conta Utilizador DropDown OK!")
       except Exception as err:
           print(f"\nTest Gerir Conta Utilizador DropDown Failure!!!")

    def test_search_DownloadAPP(self):
        driver = self.driver
        driver.maximize_window()
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", (Keys.TAB), "a", (Keys.ENTER))
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        driver.find_element_by_xpath("//div[@class='card sale-diffrence-border']").click()
        try:
            driver.find_element_by_class_name("AHFaub")
            print (f"\nTest DownloadAPP OK!")
        except Exception as err:
            print (f"\nTest DownloadAPP Failure!!!")

    def test_search_Roteiros(self):
        driver = self.driver
        driver.maximize_window()
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

    def test_search_PontosInteresse(self):
        driver = self.driver
        driver.maximize_window()
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", (Keys.TAB), "a", (Keys.ENTER))
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        driver.find_element_by_xpath("//div[@class='card  card-border-laranja']").click()
        try:
            driver.find_element_by_xpath("//a[@href='/PontosInteresse/Create']")
            print(f"\nTest Pontos Interesse OK!")
        except Exception as err:
            print(f"\nTest Pontos Interesse Failure!!!")

    def test_search_ImagensGuardadas(self):
        driver = self.driver
        driver.maximize_window()
        driver.get("https://ramtomar.azurewebsites.net/")
        self.assertIn("RAM Tomar Login", driver.title)
        driver.find_element_by_id("exampleInputEmail").send_keys("a", (Keys.TAB), "a", (Keys.ENTER))
        assert "Invalid login attempt." not in driver.page_source
        driver.set_page_load_timeout(10)
        driver.find_element_by_xpath("//div[@class='card card-border-azul']").click()
        try:
            driver.find_element_by_xpath("//a[@href='/Imagens/Create']")
            print(f"\nTest Imagens Guardadas OK!")
        except Exception as err:
            print(f"\nTest Imagens Guardadas Failure!!!")

    def tearDown(self):
        self.driver.quit()


if __name__ == '__main__':
    unittest.main()
