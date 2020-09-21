GetAsyncMoney();
let timerId = setInterval(()=>GetAsyncMoney(), 3600000);

function GetAsyncMoney() {
    var request = new XMLHttpRequest();
    request.open("GET", "https://www.cbr-xml-daily.ru/daily_json.js", true); 
    request.onload = function (e) {
        if ((request.readyState === 4) && (request.status === 200)) {
            var rates = JSON.parse(request.responseText);
            CBR_XML_Daily_Ru(rates);
        } else {
            console.error(request.statusText);
        }
    };
    request.onerror = function (e) {
    console.error(request.statusText);
    };
    request.send(null); 
}

function CBR_XML_Daily_Ru(rates) {
            
        var JPYrate = rates.Valute.JPY.Value.toFixed(4).replace('.', ',');
        var JPY = document.getElementById('JPY');
        JPY.innerHTML = JPY.innerHTML.replace('00,0000', JPYrate);
            
        var USDrate = rates.Valute.USD.Value.toFixed(4).replace('.', ',');
        var USD = document.getElementById('USD');
        USD.innerHTML = USD.innerHTML.replace('00,0000', USDrate);
              
        var EURrate = rates.Valute.EUR.Value.toFixed(4).replace('.', ',');
        var EUR = document.getElementById('EUR');
        EUR.innerHTML = EUR.innerHTML.replace('00,0000', EURrate);
}

        