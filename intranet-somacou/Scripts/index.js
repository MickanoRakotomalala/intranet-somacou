
document.addEventListener("DOMContentLoaded", () => {
    let typedInstances = []; // Stocker les instances

    function createTypedInstance(selector, strings) {
        const element = document.querySelector(selector);
        if (element) { // Vérifie si l'élément existe
            const instance = new Typed(selector, {
                strings: strings,
                typeSpeed: 100,
                backSpeed: 60,
                loop: true,
                cursorChar: "" // Rendre le curseur invisible
            });
            typedInstances.push(instance);
        } else {
            console.info(`You changed the page`);
        }
    }

    // Création des instances uniquement si les éléments existent
    createTypedInstance(".typing_one", ["Différents coloris de <br> Draps et Oreillers"]);
    createTypedInstance(".typing_two", ["Un large Choix <br> de Couvertures : <br> Acrylor, Martine ..."]);
    createTypedInstance(".typing_three", ["Divers articles <br> de Soins : <br> Coton Hydrophile, Compresse ..."]);
    createTypedInstance(".typing_four", ["Une large Collection <br> pour le Bain : <br> Serviette de Bain, Tapis de Bain ..."]);

    // Nettoyer les instances au changement de page
    window.addEventListener("beforeunload", () => {
        typedInstances.forEach(instance => instance.destroy());
    });
});


