// Active
document.addEventListener("DOMContentLoaded", function () {
    // Récupérer le chemin de l'URL actuelle
    const currentPath = window.location.pathname;

    // Identifier les liens de navigation
    const links = document.querySelectorAll(".nav-link");

    // Supprimer la classe 'active' de tous les liens
    links.forEach(link => {
        link.classList.remove("active");
    });

    // Parcourir les liens et activer celui correspondant à l'URL actuelle
    links.forEach(link => {
        const linkPath = new URL(link.href).pathname;

        // Vérifier si l'URL du lien correspond au chemin actuel
        if (currentPath === linkPath) {
            link.classList.add("active");
        }
    });
});