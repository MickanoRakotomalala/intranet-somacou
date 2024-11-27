const DefinitionElement = document.getElementById("Def");
const ResponsabilityElement = document.getElementById("Resp");

function showDef() {
    DefinitionElement.hidden = false;

    ResponsabilityElement.hidden = true;
    console.log('Def');
}

function showResponsability() {
    ResponsabilityElement.hidden = false;

    DefinitionElement.hidden = true;
    console.log('Resp');
}