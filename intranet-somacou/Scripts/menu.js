//Architecture
//Sélection des éléments Architecture
const elementsArchi = {
    menuNetwork: document.getElementById("menunetwork"),
    networkDetails: document.getElementById("networkd"),
    networkImg: document.getElementById("networkimg"),
    snetworkDetails: document.getElementById("snetworkd"),
    snetworkImg: document.getElementById("snetworkimg")
};

// Fonction générique pour afficher une section
function showSectionArchi({ visibleId, activeMenu, activeList, consoleMessage }) {
    //Réinitialiser tous les éléments
    elementsArchi.networkDetails.hidden = true;
    elementsArchi.networkImg.hidden = true;
    elementsArchi.menuNetwork.classList.remove("menuactive");
    elementsArchi.snetworkDetails.classList.remove("listactive");
    elementsArchi.snetworkImg.classList.remove("listactive");

    //Afficher les éléments spécifiques
    if (visibleId) elementsArchi[visibleId].hidden = false;
    if (activeMenu) elementsArchi[activeMenu].classList.add("menuactive");
    if (activeList) elementsArchi[activeList].classList.add("listactive");

    console.log(consoleMessage);
};

//Fonction spécifique pour les sectionArchi
function shownetworkd() {
    showSectionArchi({
        visibleId: "networkDetails",
        activeMenu: "menuNetwork",
        activeList: "snetworkDetails",
        consoleMessage: "Network Details"
    });
}
function shownetworkimg() {
    showSectionArchi({
        visibleId: "networkImg",
        activeMenu: "menuNetwork",
        activeList: "snetworkImg",
        consoleMessage: "Architect Network Image"
    })
}

// MENU DSI
// Sélection des éléments DSI
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
const userResponsible = sessionData.getAttribute("data-responsible");

console.log("userRole:", userRole); // Vérifier la valeur de userRole
console.log("userPoste:", userPoste); // Vérifier la valeur de userPoste
console.log("userResponsible:", userResponsible);
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

                        //badgeColor
                    let badgeColor = '';
                    switch (incident.Etat) {
                            case 'Nouveau':
                                badgeColor = 'bg-secondary';
                                break;
                            case 'En_cours':
                                badgeColor = 'bg-warning';
                                break;
                            case 'Résolu':
                                badgeColor = 'bg-success';
                                break;
                            case 'Non_résolu':
                                badgeColor = 'bg-danger';
                                break;
                            default:
                                badgeColor = 'bg-info';
                                break;
                    }

                    let Etat = incident.Etat;
                    console.log("Etat :", Etat);

                    //Variable pour encoder les apostrophes dans le champ observation
                    const sanitizedObservation = incident.Observation ? incident.Observation.replace(/'/g, "\\'") : "";

                    let additionalColumnsEdit = '';
                    if ((userRole === "Admin" || userRole === "Chef") && (userPoste === "Developer" || userPoste === "HelpDesk") && !incident.Responsible && Etat === "Nouveau") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-outline-secondary" type="button" onclick="openEditModal(${incident.Id}, '${incident.Etat}','${incident.Details}','${incident.Type}','${sanitizedObservation}')">
                                    <i class="bi bi-pencil-square"></i>
                                </button>
                            </td>
                        `;
                    } else if ((userRole === "Chef") && (userPoste === "Developer" || userPoste === "HelpDesk") && Etat === "Résolu") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-success" type="button">
                                    <i class="bi bi-check2-square"></i>
                                </button>
                            </td>
                        `;
                    } else if ((userRole === "Chef") && (userPoste === "Developer" || userPoste === "HelpDesk") && Etat === "En_cours") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-outline-warning" type="button" onclick="openEditModal(${incident.Id}, '${incident.Etat}','${incident.Details}','${incident.Type}','${sanitizedObservation}')">
                                    <i class="bi bi-hourglass-split"></i>
                                </button>
                            </td>
                        `;
                    } else if ((userRole === "Chef") && (userPoste === "Developer" || userPoste === "HelpDesk") && Etat === "Non_résolu") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-danger" type="button">
                                    <i class="bi bi-x-circle"></i>
                                </button>
                            </td>
                        `;
                    } else if ((userRole === "Admin") && (userPoste === "Developer" || userPoste === "HelpDesk") && Etat === "Résolu") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-outline-success" type="button" onclick="openEditModal(${incident.Id}, '${incident.Etat}','${incident.Details}','${incident.Type}','${sanitizedObservation}')">
                                    <i class="bi bi-check2-square"></i>
                                </button>
                            </td>
                        `;
                    } else if ((userRole === "Admin") && (userPoste === "Developer" || userPoste === "HelpDesk") && Etat === "En_cours") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-outline-warning" type="button" onclick="openEditModal(${incident.Id}, '${incident.Etat}','${incident.Details}','${incident.Type}','${sanitizedObservation}')">
                                    <i class="bi bi-hourglass-split"></i>
                                </button>
                            </td>
                        `;
                    } else if ((userRole === "Admin") && (userPoste === "Developer" || userPoste === "HelpDesk") && Etat === "Non_résolu") {
                        additionalColumnsEdit = `
                            <td>
                                <button class="btn btn-outline-danger" type="button" onclick="openEditModal(${incident.Id}, '${incident.Etat}','${incident.Details}','${incident.Type}','${sanitizedObservation}')">
                                    <i class="bi bi-x-circle"></i>
                                </button>
                            </td>
                        `;
                    }

                    let additionalColumnsTrash = '';
                    if (userRole === "Admin") {
                        additionalColumnsTrash = `
                            <td>
                                <button class="btn btn-outline-danger" type="button" onclick="openDeleteModal(${incident.Id},'${incident.Details}')">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </td>
                        `;
                    }

                    row.innerHTML = `
                        <td>${incident.UserName}</td>
                        <td>${incident.Phone || ''}</td>
                        <td>${incident.Type}</td>
                        <td>${incident.Details}</td>
                        <td>${FormatDate(incident.CreatedDate)}</td>
                        <td>
                            <span class="badge rounded-pill text-white ${badgeColor}">${incident.Etat}</span>
                        </td >
                        <td>${incident.UpdateDate ? FormatDate(incident.UpdateDate) : ''}</td>
                        <td>${incident.Responsible || ''}</td>
                        <td>${incident.Observation || ''}</td>
                        ${additionalColumnsEdit}
                        ${additionalColumnsTrash}
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

function openDeleteModal(id,details) {
    console.log("ID de l'incident à supprimer :", id)
    document.getElementById("incidentID").value = id;
    document.getElementById("incidentDetailsDelete").value = details;

    //ouvrir mon modal
    $("#deletemodal").modal('show');
}

// Gérer la soumission du formulaire via AJAX
document.getElementById("deleteIncidentForm").addEventListener("submit", function (e) {
    e.preventDefault();

    // Créer un FormData à partir du formulaire
    const formData = new FormData(this);
    console.log("FormData content:", [...formData]); // Debug

    fetch("/Home/DeleteIncident", {
        method: "POST",
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                showMessage("L'Incident a été supprimé avec succès !", 'success');
                // Fermer le modal
                const deleteModal = bootstrap.Modal.getInstance(document.getElementById('deletemodal'));
                deleteModal.hide();
                showListInc();
            } else {
                showMessage('Erreur lors de la suppression : ' + data.message, 'error');
                console.log("Erreurs :", data.errors);
            }
        })
        .catch(error => {
            console.error("Erreur lors de la suppression :", error);
        });
});


//VALIDATION FORMULAIRE EDIT INCIDENT - DSI
// Fonction pour ouvrir le modal et remplir les champs
function openEditModal(id,etat,details,type,observation) {
    console.log("ID de l'incident :", id);
    console.log("Type de l'incident :", type);
    console.log("Details de l'incident :", details);
    console.log("État de l'incident :", etat);
    console.log("Observation :", observation);

    // Remplir le champ caché pour l'ID de l'incident
    document.getElementById("incidentId").value = id;
    document.getElementById("incidentType").value = type;
    document.getElementById("incidentDetails").value = details;
    document.getElementById("incidentObservation").value = observation;

    // Effacer les anciens <select> (s'il y en a)
    const formEtat = document.getElementById("Form_Etat");
    formEtat.innerHTML = ''; // Vider l'élément

    // Créer un nouveau <select> pour l'état
    const etatSelect = document.createElement("select");
    etatSelect.name = "Etat";
    etatSelect.id = "Etat";
    etatSelect.classList.add("form-control"); // Ajouter la classe Bootstrap

    // Ajouter les options pour l'état
    const etats = ["Nouveau", "En_cours", "Résolu", "Non_résolu"];
    etats.forEach(e => {
        const option = document.createElement("option");
        option.value = e;
        option.textContent = e;
        etatSelect.appendChild(option);
    });
        etatSelect.value = etat; // Sélectionner l'état

    // Ajouter le <select> créé dans la div Form_Etat
    formEtat.appendChild(etatSelect);

        // Ajouter un écouteur d'événements pour détecter les changements de l'état
        etatSelect.addEventListener("change", function () {
            const observationField = document.getElementById("incidentObservation");
            const observationError = document.getElementById("Error");

            if (this.value === "Non_résolu" ) {
                observationField.setAttribute("required", "required");
                observationField.classList.add("is-invalid"); // Ajoute une classe visuelle Bootstrap
                observationField.style.border = '1px solid Red';
                observationError.classList.remove("d-none"); //Afficher le message
                observationError.textContent = "Le champ Observation est requis";
                observationField.onkeydown = function () {
                    observationField.classList.remove("is-invalid"); // Retire la classe visuelle Bootstrap
                    observationField.style.border = '1px solid Green';
                    observationError.classList.add("d-none"); //Cacher le message
                }
            } else {
                    observationField.removeAttribute("required");
                    observationField.classList.remove("is-invalid"); // Retire la classe visuelle Bootstrap
                    observationField.style.border = '1px solid Green';
                    observationError.classList.add("d-none"); //Cacher le message
            }
        });

        // Définir initialement l'état du champ Observation en fonction de la valeur actuelle
        if (etat === "Non_résolu") {
            document.getElementById("incidentObservation").setAttribute("required", "required");
        }

    // Ouvrir le modal
    $("#EditIncident").modal('show');
}




    // Gérer la soumission du formulaire via AJAX
    document.getElementById("editIncidentForm").addEventListener("submit", function (e) {
        e.preventDefault();

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
                        showMessage("L'Incident est à jour avec succès !",'success')
                        // Fermer le modal
                        const editModal = bootstrap.Modal.getInstance(document.getElementById('EditIncident'));
                        editModal.hide();
                        showListInc();
                    } else {
                        // Si une erreur de validation se produit
                        showMessage('Erreur lors de la mise à jour de l\'incident' + data.message,'error')
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
function showMessage(message, type) {
    // Créez un élément div pour le message
    const messageDiv = document.createElement('div');
    messageDiv.className = 'message flex-column align-items-center justify-content-center';
    //Champ Details
    const Details = document.getElementById("Details");

    // Style de base pour le message
    messageDiv.style.position = 'fixed';
    messageDiv.style.top = '220px'; // Position en haut de la page
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
    messageDiv.style.transition = 'top 12s ease-out, opacity 0.5s ease-out';
    messageDiv.style.opacity = '1';

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
    progressBarFill.style.transition = 'width 8s linear';

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
        messageDiv.style.top = '20px';
    }, 10);

    // Supprimez le message après 10 secondes
    setTimeout(() => {
        messageDiv.style.opacity = '0';
        setTimeout(() => {
            messageDiv.remove();
        }, 800);
    }, 8000);
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
                    showMessage('L\'Incident a été enregistré avec succès', 'success');

                    // Réinitialisez le formulaire
                    $('#incidentForm')[0].reset();
                } else {
                    // Affichez les erreurs retournées par le serveur
                    if (response.errors && response.errors.length > 0) {
                        showMessage(response.errors.join(', '), 'error');
                    } else {
                        showMessage('Erreur lors de l\'enregistrement de l\'incident', 'error');
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


/*Menu DSI*/


