GetAsyncMoney();
      function GetAsyncMoney() {
        var request = new XMLHttpRequest();
        request.open("GET", "https://www.cbr-xml-daily.ru/daily_jsonp.js", true); 
        request.onload = function (e) {
          if ((request.readyState === 4) && (request.status === 200)) {
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
        function trend(current, previous) {
                  if (current > previous) return ((' ▲').fontcolor("maroon"));
                  if (current < previous) return ((' ▼').fontcolor("maroon"));
                  return '';
                }
            
                var JPYrate = rates.Valute.JPY.Value.toFixed(4).replace('.', ',');
                var JPY = document.getElementById('JPY');
                JPY.innerHTML = JPY.innerHTML.replace('00,0000', JPYrate);
                JPY.innerHTML += trend(rates.Valute.JPY.Value, rates.Valute.JPY.Previous);
            
                var USDrate = rates.Valute.USD.Value.toFixed(4).replace('.', ',');
                var USD = document.getElementById('USD');
                USD.innerHTML = USD.innerHTML.replace('00,0000', USDrate);
                USD.innerHTML += trend(rates.Valute.USD.Value, rates.Valute.USD.Previous);
              
                var EURrate = rates.Valute.EUR.Value.toFixed(4).replace('.', ',');
                var EUR = document.getElementById('EUR');
                EUR.innerHTML = EUR.innerHTML.replace('00,0000', EURrate);
                EUR.innerHTML += trend(rates.Valute.EUR.Value, rates.Valute.EUR.Previous);
              }

        