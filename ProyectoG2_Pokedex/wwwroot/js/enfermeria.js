const enfermeras = [
    { id: 1, nombre: "Enfermera Joy", disponible: true },
    { id: 2, nombre: "Enfermera Ruby", disponible: true },
    { id: 3, nombre: "Enfermera Sapphire", disponible: false }
];

const pokemones = [
    { id: 1, nombre: "Pikachu", estado: "Herido" },
    { id: 2, nombre: "Charmander", estado: "Envenenado" },
    { id: 3, nombre: "Bulbasaur", estado: "Cansado" }
];

const listaEnfermeras = document.getElementById("lista-enfermeras");
const listaPokemones = document.getElementById("lista-pokemones");
const btnAsignar = document.getElementById("btn-asignar");

function renderEnfermeras() {
    listaEnfermeras.innerHTML = "";
    enfermeras.forEach((enfermera) => {
        const enfermeraItem = document.createElement("li");
        enfermeraItem.textContent = `${enfermera.nombre} (${enfermera.disponible ? "Disponible" : "Ocupada"})`;
        enfermeraItem.dataset.id = enfermera.id;
        enfermeraItem.className = `list-group-item ${enfermera.disponible ? "list-group-item-success" : "list-group-item-danger"}`;
        listaEnfermeras.appendChild(enfermeraItem);
    });
}

function renderPokemones() {
    listaPokemones.innerHTML = "";
    pokemones.forEach((pokemon) => {
        const pokemonItem = document.createElement("li");
        pokemonItem.textContent = `${pokemon.nombre} (${pokemon.estado})`;
        pokemonItem.dataset.id = pokemon.id;
        pokemonItem.className = "list-group-item";
        listaPokemones.appendChild(pokemonItem);
    });
}

function asignarPokemon() {
    const enfermeraDisponible = enfermeras.find((e) => e.disponible);
    const pokemonHerido = pokemones.find((p) => p.estado !== "Curado");

    if (!enfermeraDisponible) {
        alert("No hay enfermeras disponibles en este momento.");
        return;
    }

    if (!pokemonHerido) {
        alert("No hay Pokémon que necesiten atención.");
        return;
    }

    enfermeraDisponible.disponible = false;
    pokemonHerido.estado = "Curado";

    alert(`${enfermeraDisponible.nombre} está cuidando de ${pokemonHerido.nombre}.`);

    renderEnfermeras();
    renderPokemones();

    setTimeout(() => {
        enfermeraDisponible.disponible = true;
        renderEnfermeras();
    }, 5000);
}

function init() {
    renderEnfermeras();
    renderPokemones();
    btnAsignar.addEventListener("click", asignarPokemon);
}

document.addEventListener("DOMContentLoaded", init);
