//RH
const DefinitionElement = document.getElementById("Def");
const ResponsabilityElement = document.getElementById("Resp");
const cEmployeur = document.getElementById("cEmployeur");
const cSalary = document.getElementById("cSalary");
const menuDescri = document.getElementById("menudescri");
const menuCode = document.getElementById("menucode");
const listDef = document.getElementById("listdef");
const listResp = document.getElementById("listresp");
const listEmployeur = document.getElementById("listEmployeur");
const listSalary = document.getElementById("listSalary");

function showDef() {
    DefinitionElement.hidden = false;
    listDef.classList.add("listactive");
    menuDescri.classList.add("menuactive");

    ResponsabilityElement.hidden = true;
    listResp.classList.remove("listactive");
    cEmployeur.hidden = true;
    listEmployeur.classList.remove("listactive");
    cSalary.hidden = true;
    listSalary.classList.remove("listactive");

    menuCode.classList.remove("menuactive");
    console.log('Def');
}

function showResponsability() {
    ResponsabilityElement.hidden = false;
    listResp.classList.add("listactive");
    menuDescri.classList.add("menuactive");

    DefinitionElement.hidden = true;
    listDef.classList.remove("listactive");
    cEmployeur.hidden = true;
    listEmployeur.classList.remove("listactive");
    cSalary.hidden = true;
    listSalary.classList.remove("listactive");

    menuCode.classList.remove("menuactive");
    console.log('Resp');
}

function showEmployeur() {
    cEmployeur.hidden = false;
    listEmployeur.classList.add("listactive");
    menuCode.classList.add("menuactive");

    DefinitionElement.hidden = true;
    listDef.classList.remove("listactive");
    ResponsabilityElement.hidden = true;
    listResp.classList.remove("listactive");
    cSalary.hidden = true;
    listSalary.classList.remove("listactive");

    menuDescri.classList.remove("menuactive");
    console.log('Employeur');
}

function showSalary() {
    cSalary.hidden = false;
    listSalary.classList.add("listactive");
    menuCode.classList.add("menuactive");

    DefinitionElement.hidden = true;
    listDef.classList.remove("listactive");
    ResponsabilityElement.hidden = true;
    listResp.classList.remove("listactive");
    cEmployeur.hidden = true;
    listEmployeur.classList.remove("listactive");

    menuDescri.classList.remove("menuactive");
    console.log('Salary');
}

// MENU DSI
// Sélection des éléments
const elements = {
    menuDsi: document.getElementById("menudsi"),
    Idsi: document.getElementById("idsi"),
    Rdsi: document.getElementById("rdsi"),
    Sidsi: document.getElementById("sidsi"),
    Srdsi: document.getElementById("srdsi"),
    menuIncident: document.getElementById("menuinc"),
    AddIncident: document.getElementById("addinc"),
    DetailInc: document.getElementById("detailinc"),
};

// Fonction générique pour afficher une section
function showSection({ visibleId, activeMenu, activeList, consoleMessage }) {
    // Réinitialiser tous les éléments
    elements.Idsi.hidden = true;
    elements.Rdsi.hidden = true;
    elements.AddIncident.hidden = true;
    elements.menuDsi.classList.remove("menuactive");
    elements.menuIncident.classList.remove("menuactive");
    elements.Sidsi.classList.remove("listactive");
    elements.Srdsi.classList.remove("listactive");
    elements.DetailInc.classList.remove("listactive");

    // Afficher les éléments spécifiques
    if (visibleId) elements[visibleId].hidden = false;
    if (activeMenu) elements[activeMenu].classList.add("menuactive");
    if (activeList) elements[activeList].classList.add("listactive");

    console.log(consoleMessage);
}

// Fonctions spécifiques pour les sections
function showIdsi() {
    showSection({
        visibleId: "Idsi",
        activeMenu: "menuDsi",
        activeList: "Sidsi",
        consoleMessage: "Info DSI",
    });
}

function showRdsi() {
    showSection({
        visibleId: "Rdsi",
        activeMenu: "menuDsi",
        activeList: "Srdsi",
        consoleMessage: "Rôle DSI",
    });
}

function showInc() {
    showSection({
        visibleId: "AddIncident",
        activeMenu: "menuIncident",
        activeList: "DetailInc",
        consoleMessage: "Add Incident",
    });
}

// Gérer les ancres au chargement de la page
document.addEventListener("DOMContentLoaded", function () {
    // Récupérer l'ancre actuelle
    var anchor = location.hash.substring(1); // Récupère l'ancre sans le #
    console.log("Current hash:", anchor);

    if (anchor && elements[anchor]) {
        // Affiche l'élément correspondant
        elements[anchor].hidden = false;

        // Gérer les affichages spécifiques selon l'ancre
        if (anchor === "addinc") {
            showInc();
        }

        // Scroller jusqu'à l'élément (si nécessaire)
        var element = document.getElementById(anchor);
        if (element) {
            element.scrollIntoView({ behavior: "smooth", block: "start" });
        }
    }
});

