const Definition = document.getElementById('Definition');
const Responsability = document.getElementById('Responsability');

function Definition() {
    Responsability.classList.remove('col-md-9');
    Responsability.hidden = true;

    Definition.classList.add('col-md-9');
    Definition.hidden = false;
}