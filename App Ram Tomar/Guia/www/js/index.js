var container = document.getElementById('container');

var app = {
    // Application Constructor
    initialize: function () {
        document.addEventListener('deviceready', this.onDeviceReady.bind(this), false);

    },

    // deviceready Event Handler
    //
    // Bind any cordova events here. Common events are:
    // 'pause', 'resume', etc.

    onDeviceReady: function () {
        this.receivedEvent('deviceready');


        var onSuccess = function (position) {
            var topo = document.getElementById('topo');
            var body = document.body;
            body.classList.add('overflow');

            var currentRoteiro;

            //buscar o div criado no html
            var mapa = document.getElementById('mapid');
            //criar o mapa atraves da biblioteca da leaflet com a posiçao definida e zoom
            var mymap = L.map('mapid').setView([39.60360511, -8.40795278], 16);

            document.addEventListener("online", onOnline, false);

            function onOnline() {
                L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                }).addTo(mymap);
            }
                onOnline();

            //vai buscar a posição inicial quando inicia a app
            navigator.geolocation.getCurrentPosition(function (location) {
                var latlng = new L.LatLng(location.coords.latitude, location.coords.longitude);
            });

            mymap.on('locationfound', onLocationFound);

            var jsonData;
            var control;
            //buscas do elementos criados no html
            var btPos = document.getElementById('btPosicao');
            var btRot = document.getElementById('btRoteiro');
            var icon = document.getElementById('idIcon');
            var divInfo = document.getElementById('infoAdicional');
            var divRot = document.getElementById('infoRoteiro');
            var divFullImg = document.getElementById('fullImg');

            var br = document.createElement('br');

            //funcão para remover painel de direções gerado automaticamente para o trajeto
            function removeRoutingControl() {
                if (control != null) {
                    mymap.removeControl(control);
                    control = null;
                }
            };

            //função para abrir a imagem no ecra inteiro com opção de zoom
            function ecraImagem(imgP) {

                var topo = document.getElementById('topo');
                topo.classList.add('hidden');
                divInfo.classList.add("hidden");
                divRot.classList.add("hidden");
                divFullImg.classList.remove('hidden');
                //é criado um canvas com a ajuda do ficheiro img-touch-canvas.js usar touch gestures no dispositivo
                var gesturableImg = new ImgTouchCanvas({
                    canvas: document.getElementById('mycanvas'),
                    path: "" + imgP + "",
                });
                document.body.style.background = "#000000";
            }

            /* Busca o div do Acerca e o Buttão do sobre e faz o onclick*/
            var divAcerca = document.getElementById('idAcerca');
            var btSobre = document.getElementById('idSobreBt');
            btSobre.onclick = mostraSobre => {
                divAcerca.classList.remove('hidden');
                mapa.classList.add('hidden');
                divInfo.classList.add('hidden');
                divRot.classList.add("hidden");
                btPos.classList.add('hidden');
                btRot.classList.add('hidden');
                body.classList.remove('overflow');
            }
            /****************************************************************/

            var idP = document.createElement('p');
            divInfo.appendChild(idP);

            //trabalha o evento do botao dos dispositivos para voltar atras
            document.addEventListener("backbutton", onBackKeyDown, false);
            function onBackKeyDown(e) {

                //sair da aplicação quando esta está no mapa
                if (mapa.classList.contains('hidden') === false) {

                    navigator.app.exitApp();

                    /* *************** para sair da imagem ***************  */
                } else if (topo.classList.contains('hidden') === true) {

                    window.scrollTo(0, 0);
                    document.body.style.background = "#F2F2F2";
                    topo.classList.remove('hidden');
                    divInfo.classList.remove('hidden');
                    divRot.classList.add("hidden");
                    divFullImg.classList.add('hidden');

                    /******************************************************* */
                    /* *********** sair do Sobre para o mapa  *************  */
                } else if (divAcerca.classList.contains('hidden') === false) {

                    divInfo.innerHTML = "";
                    divRot.innerHTML = "";
                    e.preventDefault();
                    window.scrollTo(0, 0);
                    btPos.classList.remove('hidden');
                    btRot.classList.remove('hidden');
                    icon.classList.remove('hidden');
                    mapa.classList.remove('hidden');
                    divInfo.classList.add('hidden');
                    divRot.classList.add("hidden");
                    divAcerca.classList.add('hidden');
                    body.classList.add('overflow');
                    mymap.closePopup();
                    /******************************************************* */
                    // sair do roteiro para o map
                } else if (divRot.classList.contains('hidden') === false) {

                    divInfo.innerHTML = "";
                    divRot.innerHTML = "";
                    e.preventDefault();
                    window.scrollTo(0, 0);
                    btPos.classList.remove('hidden');
                    btRot.classList.remove('hidden');
                    icon.classList.remove('hidden');
                    mapa.classList.remove('hidden');
                    divInfo.classList.add('hidden');
                    divRot.classList.add("hidden");
                    divAcerca.classList.add('hidden');
                    body.classList.add('overflow');
                    mymap.closePopup();
                    /******************************************************* */
                }else {
                    /* ***** sair da informação do edificio para o mapa **** */
                    divInfo.innerHTML = "";
                    divRot.innerHTML = "";
                    e.preventDefault();
                    window.scrollTo(0, 0);
                    btPos.classList.remove('hidden');
                    btRot.classList.remove('hidden');
                    icon.classList.remove('hidden');
                    mapa.classList.remove('hidden');
                    divInfo.classList.add('hidden');
                    divRot.classList.add("hidden");
                    body.classList.add('overflow');
                    mymap.closePopup();
                    /******************************************************* */
                }
            }

            setInterval(5000);
            mymap.locate({ setView: true, maxZoom: 16 });

            /* =========  Função para o butão de ir para a posição do marker ===========*/
            $('.refreshButton').on('click', function () {
                mymap.locate({ setView: true, maxZoom: 17 });
            });

            var showRoteirosList = (show) => {
                if(show) divRot.innerHTML = '';
                body.classList[show ? 'remove' : 'add']('overflow');
                btPos.classList[show ? 'add' : 'remove']('hidden');
                btRot.classList[show ? 'add' : 'remove']('hidden');
                divInfo.classList[show ? 'add' : 'remove']("hidden");
                divRot.classList[show ? 'remove' : 'add']("hidden");
                mapa.classList[show ? 'add' : 'remove']('hidden');
            }

            //Verificação do carregamento de um roteiro e na seleção de outro roteiro, apaga os markers e poligonos do roteiro anterior no mapa
            var getRoteiroByID = (roteiroID = 25) => new Promise((resolve) => {
                if(window.markers) window.markers.forEach(m => m.remove());
                if(window.polygons) window.polygons.forEach(p => p.remove());
                window.markers = [];
                window.polygons = [];
                //Carrega todos os pontos de interesse da API do roteiro selecionado
                $.getJSON(`https://ramtomar.azurewebsites.net/api/RamAPI/GetRoteiro/${roteiroID}`, function(json) {
                    jsonData = json.Pontos;
                    //let cada posição e inserir numa variavel
                    for (var i = 0; i < jsonData.length; i++) {
                        let jsons = jsonData[i];
                        //desenhar o poligno dos edificios consoantes as coordenadas lidas
                        var coordenadas=[];
                        for(var j=0; j<jsonData[i].CoordenadasPoligono.length; j++) {
                        var c=[];
                        c.push(parseFloat(jsonData[i].CoordenadasPoligono[j].Latitude));
                        c.push(parseFloat(jsonData[i].CoordenadasPoligono[j].Longitude));
                        coordenadas.push(c);
                        }

                        var polygon = L.polygon([coordenadas], {
                            color: 'red',
                            weight: '0.5',
                            fillOpacity: '0.2',
                        });

                        polygon.addTo(mymap);
                        window.polygons.push(polygon);

                        //criação de elementos para mostrar no popup quando se clica num icon ou poligno de um edificio
                        var divPopup = document.createElement('div');
                        divPopup.setAttribute('id', 'iDdivPopup');
                        var popUpTipo = document.createElement('p');
                        popUpTipo.setAttribute('id', 'idPopUpTipo');
                        popUpTipo.classList.add('item1');
                        var popUpNome = document.createElement('p');
                        popUpNome.setAttribute('id', 'idPopUpNome');
                        popUpNome.classList.add('item2');

                        var btWaypoint = document.createElement('button');
                        btWaypoint.setAttribute('id', 'idBtWaypoint');
                        btWaypoint.classList.add('btn', 'btn-warning', 'item4');
                        btWaypoint.textContent = "Traçar caminho  ";
                        var iShoes = document.createElement('i');
                        iShoes.classList.add('fas', 'fa-shoe-prints');
                        btWaypoint.appendChild(iShoes);


                        var greenIcon = new L.Icon({
                            iconUrl: './img/green.png',
                            shadowUrl: './img/shadow.png',
                            iconSize: [25, 41],
                            iconAnchor: [12, 41],
                            popupAnchor: [1, -34],
                            shadowSize: [41, 41]
                        });

                        //onclick do traçar trajeto e criação da rota com metodos do leaflet routing map
                        //em que vai buscar as coordenadas do user e faz rota ate as coordernadas do icon clicado
                        btWaypoint.onclick = waypoint => {

                            removeRoutingControl();

                            console.log(current_position._latlng.lat);

                            
                        var coord = [];
                        coord.push(parseFloat(jsons.LatitudeIcone));
                        coord.push(parseFloat(jsons.LongitudeIcone));

                            control = L.Routing.control({
                                waypoints: [
                                    L.latLng(current_position._latlng),
                                    L.latLng(coord)
                                ],
                                createMarker: function (i, wp, nWps) {
                                    if (i === nWps - 1) {
                                        // here change the starting and ending icons
                                        return L.marker(wp.latLng, {
                                            icon: greenIcon // here pass the custom marker icon instance
                                        });
                                    }
                                },
                                lineOptions: {
                                    styles: [{ color: 'red', opacity: 1, weight: 5 }],
                                },
                                draggableWaypoints: false,

                            }).addTo(mymap);


                        }

                        //////////////////POPUPS////////////////////////
                        
                        //Cria a primeira info no popup
                        popUpTipo.textContent = jsons.TipoEdificio;
                        popUpNome.textContent = jsons.Nome;
                        divPopup.appendChild(popUpTipo);
                        divPopup.appendChild(popUpNome);

                        //criação do icon dos edificios
                        var myIcon = L.icon({
                            iconUrl: 'icon.png',
                            iconSize: [30, 48],
                            iconAnchor: [15, 48],
                            popupAnchor: [-7, -45]

                        });

                        //Cria um popup para cada marker
                        var coord = [];
                        coord.push(parseFloat(jsons.LatitudeIcone));
                        coord.push(parseFloat(jsons.LongitudeIcone));

                        window.markers.push(L.marker(coord, { icon: myIcon }).addTo(mymap).bindPopup(divPopup));

                        //atraves de jquery clicar nos detalhes de um edificio e ler as suas informações
                        //Cria o botão "Detalhes" nos popups
                        var link = $('<a href="#"  class="item3" style="background-color: #17283B; color: white; text-align: center; margin-bottom: .5em; margin-left: .5em; padding: .75em; text-decoration: none; border-radius: .25rem; ">Detalhes  <i class="fas fa-info"></i></a>')
                        .click(function () {

                            body.classList.remove('overflow');
                            btPos.classList.add('hidden');
                            btRot.classList.add('hidden');
                            divInfo.classList.remove("hidden");
                            divRot.classList.add("hidden");
                            mapa.classList.add('hidden');
                            mymap.closePopup();

                            //criação de elementos e adicionados ao html
                            var hr = document.createElement('hr');
                            hr.setAttribute('id', 'idHr');
                            
                            //Cria a Linha
                            var spanLinha = document.createElement('span');
                            spanLinha.setAttribute('id', 'idSpanLinha');
                            spanLinha.textContent = "";
                            
                            //Cria o titulo antes da lista de autores
                            
                            //Nome do Edificio
                            var pNomeEdificio = document.createElement('h2');
                            pNomeEdificio.setAttribute('id', 'idNomeEdificio');
                            pNomeEdificio.textContent = jsons.Nome;
                            divInfo.appendChild(pNomeEdificio);
                            
                            //Tipo de Edificio
                            var pTipoEdificio = document.createElement('h3');
                            pTipoEdificio.setAttribute('id', 'idTipoEdificio');
                            //Coloca o texto do Tipo de Edificio no meio da linha
                            spanLinha.textContent = jsons.TipoEdificio;
                            pTipoEdificio.appendChild(spanLinha);
                            divInfo.appendChild(pTipoEdificio);

                            //atribuição dos valores existentes na API dos Pontos de Interesse no popup da Descrição de cada Edificio    
                            $.getJSON('https://ramtomar.azurewebsites.net/api/RamAPI/GetPontoInteresse/' + jsons.Id, function(json) {
                                
                                //Autores
                                var autoresTab = document.createElement('div');
                                autoresTab.setAttribute('id', 'idAutoresTab');
                                autoresTab.textContent = "Autores do projeto: " + json.Autor;
                                divInfo.appendChild(autoresTab);

                                //Localização
                                var pLocalizacao = document.createElement('p');
                                pLocalizacao.setAttribute('id', 'idLocalizacao');
                                pLocalizacao.textContent = "Localização: " + json.Localizacao;
                                divInfo.appendChild(pLocalizacao);
                            
                                //Ano
                                var pData = document.createElement('p');
                                pData.setAttribute('id', 'idData');
                                pData.textContent = "Ano: " + json.Ano;
                                divInfo.appendChild(pData);
                                
                                //Descrição
                                var pDescricao = document.createElement('p');
                                pDescricao.setAttribute('id', 'idDescricao');
                                divInfo.appendChild(pDescricao);
                                pDescricao.textContent = "Descrição: " + json.Descricao;
                                
                                //Imagens
                                divInfo.appendChild(hr);

                                var divRow = document.createElement('div');
                                divRow.setAttribute('id', 'idDivRow');
                                divRow.setAttribute('class', 'row');
                                
                                for (var j = 0; j < json.Imagens.length; j++) {
                                    var imgEdificio = json.Imagens[j];
                                    var divColMd = document.createElement('div');
                                    divColMd.setAttribute('id', 'idDivColMd');
                                    divColMd.setAttribute('class', 'col-md-4');
                                    divColMd.setAttribute('class', 'content');
                                    var divThumb = document.createElement('div');
                                    divThumb.setAttribute('class', 'thumbnail');
                                    divThumb.setAttribute('id', 'idDivThumb');
                                    var divCaption = document.createElement('div')
                                    divCaption.setAttribute('id', 'idDivCaption');
                                    divCaption.setAttribute('class', 'caption');
                                    divCaption.setAttribute('class', 'rounded-bottom');

                                    var img = document.createElement('img');
                                    var imgLegenda = document.createElement('p');
                                    var imgAutor = document.createElement('p');

                                    //lida a path da imagem para a pasta das imagens
                                    img.src = imgEdificio.Conteudo;
                                    img.setAttribute('id', 'idImagens');
                                    img.setAttribute('class', 'rounded');

                                    //onclick na imagem para ver esta com mais zoom que é mostrada inicialmente
                                    img.setAttribute('data-Path', imgEdificio.Conteudo);
                                    img.onclick = fullImg => {
                                        var pathId = fullImg.target.getAttribute('data-Path', imgEdificio.Conteudo);
                                        //é chamada a fução de abrir a imagem, função essa que leva como parametro o path da imagem
                                        ecraImagem(pathId);
                                }

                                //atribuição dos valores existentes no json
                                imgLegenda.textContent = imgEdificio.Legenda;
                                imgAutor.textContent = imgEdificio.Autor;

                                divCaption.appendChild(imgLegenda);
                                divCaption.appendChild(imgAutor);

                                divThumb.appendChild(img);
                                divThumb.appendChild(divCaption);


                                divColMd.appendChild(divThumb);

                                divRow.appendChild(divColMd);

                                divInfo.appendChild(divRow);

                            }
                            });

                            divInfo.appendChild(hr); 

                        })[0];
                        divPopup.appendChild(link);
                        divPopup.appendChild(br);
                        divPopup.appendChild(btWaypoint);

                        polygon.bindPopup(divPopup);
                    }
                    resolve();
                }); 
            })

            /* =========  Função para o butão de ir para a posição do marker ===========*/
            $('.roteiroButton').on('click', function () {
                showRoteirosList(true);
                var pCabecalhoRot = document.createElement('h4');
                pCabecalhoRot.setAttribute('id', 'idCabecalhoRot');
                pCabecalhoRot.textContent = "Lista de Roteiros:";
                divRot.appendChild(pCabecalhoRot);
                var pIntroRot = document.createElement('p');
                pIntroRot.setAttribute('id', 'idIntroRot');
                pIntroRot.textContent = "Selecione o roteiro pretendido clicando no nome";
                divRot.appendChild(pIntroRot);
                //Carrega a API dos Roteiros
                $.getJSON('https://ramtomar.azurewebsites.net/api/RamAPI/GetRoteiros', function(json) {
                    jsonData = json;
                    //let cada roteiro da API insere numa variavel
                    for (var i = 0; i < jsonData.length; i++) {
                        //Nome
                        var pRoteiro = document.createElement('h5');
                        pRoteiro.setAttribute('id', 'idRoteiro');
                        pRoteiro.textContent = jsonData[i].NomeRoteiro;
                        //Descriçao
                        var pDescricaoRot = document.createElement('p');
                        pDescricaoRot.setAttribute('id', 'IdDescRoteiro');
                        pDescricaoRot.textContent = "Descrição: " + jsonData[i].Descricao;
                        pRoteiro.dataset.id = jsonData[i].IdRoteiro;
                        pRoteiro.addEventListener("click", (evt) => {
                            getRoteiroByID(evt.currentTarget.dataset.id)
                            .then(() => showRoteirosList(false))
                        });
                        divRot.appendChild(pRoteiro);
                        divRot.appendChild(pDescricaoRot);
                    }
                });
               
                ////////////////////////////////////////////////////////////////////////////////////////////////////
            });
            mymap.on('locationfound', onLocationFound);
            var current_position;
            
             //funcoes que vao ler a posição do utilizador e marcar no mapa e remover a posição anterior
             function onLocationFound(e) {
                    
                // If utilizador fora da zona da cidade de Tomar, remove o marcador do mapa
                if (current_position) {
                    mymap.removeLayer(current_position);
                }
                // if utilizador dentro da zona de Tomar, então marcador aponta para a posição atual do mesmo
                if(e.latitude<39.620443 && e.latitude>39.59430 && e.longitude<-8.426837 && e.longitude>-8.374149)
                    current_position = L.marker(e.latlng).addTo(mymap);
                else {
                    //utilizador fora da zona de Tomar, então marcador aponta para o centro da cidade
                    e.latlng.lat= 39.60360511;
                    e.latlng.lng= -8.40795278;
                    current_position = L.marker(e.latlng).addTo(mymap);
                    
                    
                }
                
                mymap.setView(new L.LatLng(e.latlng.lat, e.latlng.lng), 16);
            }

            function onLocationError(e) {
                alert(e.message);
            }

            // wrap map.locate in a function    
            function locate() {
                mymap.locate({ setView: false, maxZoom: 16 });  
            }

            // call locate every 3 seconds... forever
            setInterval(locate, 3000);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        var onError = function (error) {
            str = 'code: ' + error.code + '\n' +
            'message: ' + error.message + '\n';
            if (error.code == 3) { // no gps
                str = "Sem sinal de GPS.";
                onSuccess();
            } 
            alert(str);
        }

        navigator.geolocation.getCurrentPosition(onSuccess, onError, { timeout: 10000, enableHighAccuracy: true });
    },

    // Update DOM on a Received Event
    receivedEvent: function (id) {
        var parentElement = document.getElementById(id);
    }
};


app.initialize();