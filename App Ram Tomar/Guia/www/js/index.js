//Vai buscar a div do mapa criada no index.html
var map = document.getElementById('mapid');
//criar o mapa atraves da biblioteca da leaflet com as coordenadas iniciais do utilizador
var RAMmap = L.map('mapid').locate({ setView: true, maxZoom: 14 });

// Devido ao consumo da API o estado offline da app foi removido
document.addEventListener("online", onOnline, true);
function onOnline() {
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 18,
        minZoom: 14,
        attribution: attribution
    }).addTo(mymap);
}
onOnline();

//Custom icon for current position
const markerCurrent = L.icon({
    iconUrl: 'img/green.png',
    iconSize: [75, 75],
    iconAnchor: [25, 16]
});

var marker;
var circle;
//coloca o mapa na localização do utilizador
navigator.geolocation.getCurrentPosition(function (location) {
    var latlng = new L.LatLng(location.coords.latitude, location.coords.longitude);
    //Criar o marcador na localização do utilizador
    marker = L.marker(latlng, { icon: markerCurrent }).addTo(mymap);

    //Fetch dos pontos de intresse colocados na API
    fetch('https://ramtomar.azurewebsites.net/api/pontosapi')
        .then((res) => { return res.json() })
        .then((data) => {
            let result = data.data;                        
            result.forEach((data) => {
                circle = L.circle([data.coordinate1, data.coordinate2], {
                    color: 'green',
                    fillColor: '#aa3',
                    fillOpacity: 0.5,
                    radius: 100
                }).addTo(RAMmap);

                L.marker([data.coordinate1, data.coordinate2]).bindPopup(`
                            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content pontoInter" style="height:300px; width:300px;overflow:scroll;">
                                    <div class="modal-header">
                                        <h1 class="modal-title" id="exampleModalLabel">`+ data.buildingName + `</h1><hr>
                                        <h2 class="modal-title" id="exampleModalLabel">`+ data.buildingType + `</h2>
                                        <h4>Localizacão: `+ data.location + `</h4>
                                        <h5>Ano: `+ data.dates + `</h5>
                                    </div><hr>
                                    <div class="modal-body">
                                        <p>`+ data.description + `</p>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-info btn-lg" onclick="PDI()">Ver detalhes</button>
                                    </div><br>
                                </div>
                            </div>
                            </div>`).addTo(RAMmap);
            });

        });
    marker.bindPopup("<b>You are here now!</b>").openPopup();
});

function PDI(){
    document.getElementById("myModal");
}