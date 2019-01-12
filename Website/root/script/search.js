function search() {
    //element variable
    var input, filter, ul, li, a, i;
    //get the search input
    input = document.getElementById('searchString');
    //filter the search to uppercase
    filter = input.value.toUpperCase();
    //get the list of products
    ul = document.getElementById("myUl");
    li = ul.getElementsByTagName('li');
    //loop through the products to find the search input
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByClassName("currentProduct")[0];
        if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}