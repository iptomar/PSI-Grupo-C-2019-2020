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
            var topo = document.getElementById('topo');
            var body = document.body;
            body.classList.add('overflow');

            //buscar o div criado no html
            var mapa = document.getElementById('mapid');
            //criar o mapa atraves da biblioteca da leaflet com a posiçao definida e zoom
            var mymap = L.map('mapid').setView([39.60360511, -8.40795278], 16);
            //.locate({setView: true, maxZoom: 16});
            var estado = 0;

            //Como o consumo da API não pode funcionar em Offline, deixamos apenas o modo online
            document.addEventListener("online", onOnline, false);

            function onOnline() {
                L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                }).addTo(mymap);
            }
                onOnline();
                
                //Custom icon for current position
                const markerCurrent = L.icon({
                    iconUrl: 'img/green.png',
                    iconSize: [25, 25],
                    iconAnchor: [25, 16]
                });

                var marker;
                //posição inicial
                navigator.geolocation.getCurrentPosition(function (location) {
                   var latlng = new L.LatLng(location.coords.latitude, location.coords.longitude);
                   //marcador na posição inicial
                   marker = L.marker(latlng, { icon: markerCurrent}).addTo(mymap);

                   marker.bindPopup("<b>Sua posição atual</b>").openPopup();     
               });


                var jsonData;
                var control;
                //buscas do elementos criados no html
                var btPos = document.getElementById('btPosicao');
                var icon = document.getElementById('idIcon');
                var divInfo = document.getElementById('infoAdicional');
                var divFullImg = document.getElementById('fullImg');

            //Funcão para fazer fetch das cordenadas dos edificios
            let geojson;
            $.getJSON('https://ramtomar.azurewebsites.net/api/pontosapi', function(data) {
              geojson = data;
              const dataPoint = geojson.datapoint;
            
              // store all the coordinates in this array o be able to iterate over the markers array
              let coordinates = [];
            
              // populate coordinates array with all the markers
              for (let i = 0; i < dataPoint.length; i++) {
                coordinates.push([Number(dataPoint[i].lat1), Number(dataPoint[i].long1)], [Number(dataPoint[i].lat2), Number(dataPoint[i].long2)]);
              };
            
              // visualize the markers on the map
              for (let i = 0; i < coordinates.length; i++) {
                L.marker(coordinates[i]).addTo(map)
                  .bindPopup("<b>Latitude:</b> " + coordinates[i][0] + " <b>Longitude:</b> " + coordinates[i][1]);
              };
            });

            var br = document.createElement('br');

            //função para abrir a imagem no ecra inteiro com opção de zoom
            function ecraImagem(imgP) {

                var topo = document.getElementById('topo');
                topo.classList.add('hidden');
                divInfo.classList.add("hidden");

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
                btPos.classList.add('hidden');
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
                    divFullImg.classList.add('hidden');

                    /******************************************************* */
                    /* *********** sair do Sobre para o mapa  *************  */
                } else if (divAcerca.classList.contains('hidden') === false) {
                    // imgFull.innerHTML = "";

                    divInfo.innerHTML = "";
                    e.preventDefault();
                    window.scrollTo(0, 0);
                    btPos.classList.remove('hidden');
                    icon.classList.remove('hidden');
                    mapa.classList.remove('hidden');
                    divInfo.classList.add('hidden');
                    divAcerca.classList.add('hidden');
                    body.classList.add('overflow');
                    mymap.closePopup();
                    /******************************************************* */
                } else {
                    /* ***** sair da informação do edificio para o mapa **** */
                    //imgFull.innerHTML = "";

                    divInfo.innerHTML = "";
                    e.preventDefault();
                    window.scrollTo(0, 0);
                    btPos.classList.remove('hidden');
                    icon.classList.remove('hidden');
                    mapa.classList.remove('hidden');
                    divInfo.classList.add('hidden');
                    body.classList.add('overflow');
                    mymap.closePopup();
                    /******************************************************* */
                }
            }
        }
};

app.initialize();