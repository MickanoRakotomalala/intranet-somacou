const Definition = document.getElementById("Def");
const Responsability = document.getElementById("Resp");

function Def() {
    Definition.hidden = false;

    Responsability.hidden = true;
    //Responsability.ClassList.remove("col-md-9");
    console.log('Def');
}

function Responsability() {
    Responsability.hidden = false;
    //Responsability.ClassList.add("col-md-9");

    Definition.hidden = true;
    //Definition.ClassList.remove("col-md-9");
    console.log('Resp');
}