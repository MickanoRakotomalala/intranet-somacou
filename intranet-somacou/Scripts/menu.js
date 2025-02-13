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
    ListInc: document.getElementById("listInc"),
    RespInc: document.getElementById("respinc")
};

// Fonction générique pour afficher une section
function showSection({ visibleId, activeMenu, activeList, consoleMessage }) {
    // Réinitialiser tous les éléments
    elements.Idsi.hidden = true;
    elements.Rdsi.hidden = true;
    elements.AddIncident.hidden = true;
    elements.ListInc.hidden = true;
    elements.menuDsi.classList.remove("menuactive");
    elements.menuIncident.classList.remove("menuactive");
    elements.Sidsi.classList.remove("listactive");
    elements.Srdsi.classList.remove("listactive");
    elements.DetailInc.classList.remove("listactive");
    elements.RespInc.classList.remove("listactive");

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


// DSI
//Fonction FromDate
function FormatDate(dateString) {
    // Vérifier si la date est au format "/Date(timestamp)/"
    if (dateString.startsWith("/Date(") && dateString.endsWith(")/")) {
        // Extraire le timestamp (nombre entre parenthèses)
        const timestamp = parseInt(dateString.slice(6, -2), 10);

        // Créer un objet Date à partir du timestamp
        const date = new Date(timestamp);

        // Formater la date en "JJ/MM/AAAA HH:MM"
        const day = String(date.getDate()).padStart(2, '0'); // Jour (2 chiffres)
        const month = String(date.getMonth() + 1).padStart(2, '0'); // Mois (2 chiffres)
        const year = date.getFullYear(); // Année (4 chiffres)
        const hours = String(date.getHours()).padStart(2, '0'); // Heures (2 chiffres)
        const minutes = String(date.getMinutes()).padStart(2, '0'); // Minutes (2 chiffres)

        return `${day}/${month}/${year} ${hours}:${minutes}`;
    }

    // Si la date n'est pas au format "/Date(timestamp)/", essayer de la convertir directement
    const date = new Date(dateString);

    // Vérifier si la date est valide
    if (isNaN(date.getTime())) {
        return "Date inconnue"; // Retourner une valeur par défaut si la date est invalide
    }

    // Formater la date en "JJ/MM/AAAA HH:MM"
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');

    return `${day}/${month}/${year} ${hours}:${minutes}`;
}

// Récupérer les valeurs des data-attributes
const sessionData = document.getElementById("sessionData");
const userRole = sessionData.getAttribute("data-role");
const userPoste = sessionData.getAttribute("data-poste");

console.log("userRole:", userRole); // Vérifier la valeur de userRole
console.log("userPoste:", userPoste); // Vérifier la valeur de userPoste
function showListInc(page = 1) {
    showSection({
        visibleId: "ListInc",
        activeMenu: "menuIncident",
        activeList: "RespInc",
        consoleMessage: "List Incident",
    });

    const listDsiUrl = `/Home/ListDsi?page=${page}`;

    fetch(listDsiUrl)
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                const tbody = document.querySelector("#incidentTable tbody");
                tbody.innerHTML = ""; // Vider le contenu existant

                // Ajouter les nouvelles lignes
                data.data.forEach(incident => {
                    const row = document.createElement("tr");

                    let additionalColumns = '';
                    if ((userRole === "Admin" || userRole === "Chef") && (userPoste === "Developer" || userPoste === "HelpDesk")) {
                        additionalColumns = `
                            <td>${incident.Action || ''}</td>
                            <td>${incident.UpdateDate ? FormatDate(incident.UpdateDate) : ''}</td>
                            <td>${incident.Responsible || ''}</td>
                            <td>
                                <button class="btn btn-outline-light" type="button" onclick="openEditModal(${incident.Id}, '${incident.Etat}', '${incident.Action}','${incident.UserName}','${incident.Details}','${incident.Type}')">
                                    <i class="bi bi-pencil-square"></i>
                                </button>
                            </td>
                        `;
                    }

                    row.innerHTML = `
                        <td>${incident.UserName}</td>
                        <td>${incident.Type}</td>
                        <td>${incident.Details}</td>
                        <td>${etat = incident.Etat,
                              if (etat === "Nouveau") {

                    };
                                }</td >
                        <td>${FormatDate(incident.CreatedDate)}</td>
                        ${additionalColumns}
                    `;
                    tbody.appendChild(row);
                });

                // Mise à jour de la pagination
                updatePagination(data.pagination.currentPage, data.pagination.totalPages);
            } else {
                alert(data.message);
            }
        })
        .catch(error => {
            console.error("Erreur lors de la récupération des incidents :", error);
        });
}

// Mise à jour dynamique de la pagination
function updatePagination(currentPage, totalPages) {
    const paginationContainer = document.querySelector(".pagination");
    paginationContainer.innerHTML = ""; // Réinitialiser la pagination

    // Précédent
    paginationContainer.innerHTML += `
        <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
            <a class="page-link" href="#" onclick="showListInc(${currentPage - 1})">Précédent</a>
        </li>
    `;

    // Numéros de page
    for (let i = 1; i <= totalPages; i++) {
        paginationContainer.innerHTML += `
            <li class="page-item ${i === currentPage ? 'active' : ''}">
                <a class="page-link" href="#" onclick="showListInc(${i})">${i}</a>
            </li>
        `;
    }

    // Suivant
    paginationContainer.innerHTML += `
        <li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
            <a class="page-link" href="#" onclick="showListInc(${currentPage + 1})">Suivant</a>
        </li>
    `;
}


//VALIDATION FORMULAIRE EDIT INCIDENT - DSI
// Fonction pour ouvrir le modal et remplir les champs
function openEditModal(id, etat, action,username, details, type) {
    console.log("ID de l'incident :", id);
    console.log("État de l'incident :", etat);
    console.log("Action de l'incident :", action);
    console.log("User de l'incident :", username);
    console.log("Détails de l'incident :", details);
    console.log("Type de l'incident :", type);

    // Remplir le champ caché pour l'ID de l'incident
    document.getElementById("incidentId").value = id;
    document.getElementById("incidentUserName").value = username;
    document.getElementById("incidentDetails").value = details;
    document.getElementById("incidentType").value = type;

    // Effacer les anciens <select> (s'il y en a)
    const formEtat = document.getElementById("Form_Etat");
    const formAction = document.getElementById("Form_Action");
    formEtat.innerHTML = ''; // Vider l'élément
    formAction.innerHTML = ''; // Vider l'élément

    // Créer un nouveau <select> pour l'état
    const etatSelect = document.createElement("select");
    etatSelect.name = "Etat";
    etatSelect.id = "Etat";
    etatSelect.classList.add("form-control"); // Ajouter la classe Bootstrap

    // Ajouter les options pour l'état
    const etats = ["Nouveau", "En_cours", "Résolu", "Fermé"];
    etats.forEach(e => {
        const option = document.createElement("option");
        option.value = e;
        option.textContent = e;
        etatSelect.appendChild(option);
    });

    // Sélectionner la bonne option pour l'état
    setTimeout(() => {
        etatSelect.value = etat; // Sélectionner l'état
        console.log("Valeur sélectionnée pour Etat :", etatSelect.value);
    }, 100);

    // Ajouter le <select> créé dans la div Form_Etat
    formEtat.appendChild(etatSelect);

    // Créer un nouveau <select> pour l'action
    const actionSelect = document.createElement("select");
    actionSelect.name = "Action";
    actionSelect.id = "Action";
    actionSelect.classList.add("form-control"); // Ajouter la classe Bootstrap

    // Ajouter les options pour l'action
    const actions = ["Attente", "En_cours", "Terminé"];
    actions.forEach(a => {
        const option = document.createElement("option");
        option.value = a;
        option.textContent = a;
        actionSelect.appendChild(option);
    });

    // Sélectionner la bonne option pour l'action
    setTimeout(() => {
        actionSelect.value = action; // Sélectionner l'action
        console.log("Valeur sélectionnée pour Action :", actionSelect.value);
    }, 100);

    // Ajouter le <select> créé dans la div Form_Action
    formAction.appendChild(actionSelect);

    // Ouvrir le modal
    $("#EditIncident").modal('show');
}




    // Gérer la soumission du formulaire via AJAX
    document.getElementById("editIncidentForm").addEventListener("submit", function (e) {
        e.preventDefault();

        // S'assurer que les valeurs sélectionnées sont prises en compte avant de soumettre
        const etatSelect = document.getElementById("Etat");
        const actionSelect = document.getElementById("Action");

        // Ajouter manuellement la sélection des options
        if (!etatSelect.value) {
            etatSelect.value = document.querySelector("#Etat option").value; // Valeur par défaut
        }
        if (!actionSelect.value) {
            actionSelect.value = document.querySelector("#Action option").value; // Valeur par défaut
        }

        // Créer un FormData à partir du formulaire
        const formData = new FormData(this);

        // Vérifier le contenu de formData dans la console
        console.log("FormData content:", [...formData]);

        fetch("/Home/UpdateIncident", {
            method: "POST",
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    alert("Incident mis à jour avec succès !");
                    // Fermer le modal
                    const editModal = bootstrap.Modal.getInstance(document.getElementById('EditIncident'));
                    editModal.hide();
                    showListInc();
                } else {
                    // Si une erreur de validation se produit
                    alert("Erreur lors de la mise à jour de l'incident : " + data.message);
                    console.log("Erreurs de validation :", data.errors); // Afficher les erreurs dans la console
                    data.errors.forEach((error, index) => {
                        console.log(`Erreur ${index + 1}: ${error}`);
                    });
                }
            })
            .catch(error => {
                console.error("Erreur lors de la mise à jour de l'incident :", error);
            });
    });




//Validation formulaire AJOUT INCIDENT - DSI
function showErrorMessage(message, type) {
    // Créez un élément div pour le message
    const messageDiv = document.createElement('div');
    messageDiv.className = 'message flex-column align-items-center justify-content-center';
    //Champ Details
    const Details = document.getElementById("Details");

    // Style de base pour le message
    messageDiv.style.position = 'fixed';
    messageDiv.style.top = '80px'; // Position en haut de la page
    messageDiv.style.left = '50%'; // Centré horizontalement
    messageDiv.style.transform = 'translateX(-50%)'; // Centrage précis
    messageDiv.style.width = 'auto'; // Largeur automatique
    messageDiv.style.padding = '10px 20px'; // Padding horizontal et vertical
    messageDiv.style.color = '#fff'; // Texte blanc
    messageDiv.style.textAlign = 'center';
    messageDiv.style.zIndex = '1000'; // Assurez-vous qu'il est au-dessus des autres éléments
    messageDiv.style.boxShadow = '0 2px 4px rgba(0, 0, 0, 0.2)';
    messageDiv.style.borderRadius = '5px'; // Coins arrondis
    messageDiv.style.animation = 'slideDown 0.5s ease-out';

    // Définissez la couleur de fond et l'icône en fonction du type de message
    const icon = document.createElement('i');
    icon.style.fontSize = '1.0rem'; // Taille de l'icône
    icon.className = 'bi me-2'; // Classe de base pour Bootstrap Icons

    if (type === 'error') {
        messageDiv.style.backgroundColor = '#E57070'; // Rouge pour les erreurs
        icon.className += ' bi-x-circle'; // Icône d'erreur
        Details.style.borderColor = '#E57070';
    } else if (type === 'success') {
        messageDiv.style.backgroundColor = '#4DF0B8'; // Vert pour les succès
        icon.className += ' bi-check-circle'; // Icône de succès
    }

    // Ajoutez le texte du message
    const text = document.createElement('span');
    text.textContent = message;

    // Créez la barre de progression
    const progressBar = document.createElement('div');
    progressBar.style.width = '100%';
    progressBar.style.height = '4px';
    progressBar.style.backgroundColor = 'rgba(255, 255, 255, 0.3)';
    progressBar.style.borderRadius = '2px';
    progressBar.style.marginTop = '10px';
    progressBar.style.overflow = 'hidden';

    //Créez l'élément de remplissage de la barre de progression
    const progressBarFill = document.createElement('div');
    progressBarFill.style.width = '0%';
    progressBarFill.style.height = '100%';
    progressBarFill.style.backgroundColor = '#fff';
    progressBarFill.style.transition = 'width 5s linear';

    //Ajoutez le remplissage à la barre de progression
    progressBar.appendChild(progressBarFill);

    // Ajoutez l'icône et le texte au message
    messageDiv.appendChild(icon);
    messageDiv.appendChild(text);
    messageDiv.appendChild(progressBar);

    // Ajoutez le message au début du body
    document.body.prepend(messageDiv);

    // Démarrez l'animation de la barre de progression
    setTimeout(() => {
        progressBarFill.style.width = '100%';
    }, 10);

    // Supprimez le message après 5 secondes
    setTimeout(() => {
        messageDiv.remove();
    }, 5000);
}

$(document).ready(function () {
    $('#incidentForm').on('submit', function (e) {
        e.preventDefault(); // Empêche la soumission traditionnelle du formulaire

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    // Affichez un message de succès
                    showErrorMessage('Incident enregistré avec succès', 'success');

                    // Réinitialisez le formulaire
                    $('#incidentForm')[0].reset();
                } else {
                    // Affichez les erreurs retournées par le serveur
                    if (response.errors && response.errors.length > 0) {
                        showErrorMessage(response.errors.join(', '), 'error');
                    } else {
                        showErrorMessage('Erreur lors de l\'enregistrement de l\'incident', 'error');
                    }
                }
            },
            error: function () {
                // Affichez un message d'erreur générique en cas d'échec de la requête AJAX
                showErrorMessage('Erreur lors de la soumission du formulaire', 'error');
            }
        });
    });
});