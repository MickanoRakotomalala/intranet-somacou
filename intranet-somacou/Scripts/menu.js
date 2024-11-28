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

    DefinitionElement.hidden = true;
    listDef.classList.remove("listactive");
    ResponsabilityElement.hidden = true;
    listResp.classList.remove("listactive");
    cEmployeur.hidden = true;
    listEmployeur.classList.remove("listactive");

    menuDescri.classList.remove("menuactive");
    console.log('Salary');
}