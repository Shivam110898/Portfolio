function myMap() {
    //coordinates of the store
    var currentLocation = new google.maps.LatLng(53.231001, -0.551347);
    //map element
    var mapCanvas = document.getElementById("map");
    //center the map to the coordinates
    var mapOptions = {
        center: currentLocation,
        zoom: 10
    };
    
    var map = new google.maps.Map(mapCanvas, mapOptions);
    //set the red marker
    var marker = new google.maps.Marker({
        position: currentLocation
    });
    marker.setMap(map);
    //the window with the address
    var infowindow = new google.maps.InfoWindow({
        content: "Aqua House, Harvey St, Lincoln LN1 1TE"
    });
    infowindow.open(map, marker);
}