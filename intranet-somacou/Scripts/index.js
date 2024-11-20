let typed = new Typed(".typing_one", {
    strings: [
        "Différents coloris de <br> &nbsp; &nbsp; &nbsp; &nbsp; Draps et Oreillers",
    ],
    typeSpeed: 100,
    BackSpeed: 60,
    loop: true,
    cursorChar:"", //rendre le curseur invisible
});

let typedtwo = new Typed(".typing_two", {
    strings: [
        "Un large Choix <br> &nbsp; &nbsp; &nbsp; &nbsp; de Couvertures : <br> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Acrylor, Martine ...",
    ],
    typeSpeed: 100,
    BackSpeed: 60,
    loop: true,
    cursorChar: "", //rendre le curseur invisible
});

let typedthree = new Typed(".typing_three", {
    strings: [
        "Divers articles <br> &nbsp; &nbsp; &nbsp; &nbsp; de Soins : <br> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Coton Hydrophile, Compresse ...",
    ],
    typeSpeed: 100,
    BackSpeed: 60,
    loop: true,
    cursorChar:"", //rendre le curseur invisible
});

let typedfour = new Typed(".typing_four", {
    strings: [
        "Une large Collection <br> &nbsp; &nbsp; &nbsp; &nbsp; pour le Bain : <br> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Serviette de Bain, Tapis de Bain ...",
    ],
    typeSpeed: 100,
    BackSpeed: 60,
    loop: true,
    cursorChar:"", //rendre le curseur invisible
});

// Active
const currentLocation = location.href;
const menuItems = document.querySelectorAll('.nav-active a');

menuItems.forEach(item => {
    if (item.href === currentLocation) {
        console.log(currentLocation);
        menuItems.forEach(i => i.parentElement.classList.remove('active-item'));
        item.parentElement.classList.add('active-item');
    }
})

//Methode 2
//$(document).ready(function () {
//    // Récupère l'URL actuelle
//    var currentUrl = window.location.pathname;

//    // Parcours tous les liens de la navbar
//    $('.nav-active a').each(function () {
//        var linkUrl = $(this).attr('href');

//        // Vérifie si le lien correspond à l'URL actuelle
//        if (currentUrl === linkUrl) {
//            $(this).addClass('active-item');
//        }
//    });
//});
