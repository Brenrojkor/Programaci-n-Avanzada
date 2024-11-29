document.addEventListener("DOMContentLoaded", function () {
    cargarEnfermeras();
    cargarPokemonesPendientes();
});

function cargarEnfermeras() {
    const enfermerasList = document.getElementById('enfermeras');

    const enfermeras = [
        { id: 1, nombre: 'Joy Kanto' },
        { id: 2, nombre: 'Joy Johto' },
        { id: 3, nombre: 'Joy Hoenn' },
        { id: 4, nombre: 'Joy Sinnoh' },
        { id: 5, nombre: 'Joy Unova' },
        { id: 6, nombre: 'Joy Kalos' },
        { id: 7, nombre: 'Joy Alola' },
        { id: 8, nombre: 'Joy Galar' }
    ];

    enfermeras.forEach(enfermera => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${enfermera.nombre}</span>
            <button class="asignar-pokemon" onclick="asignarPokemon(${enfermera.id})">Asignar Pokémon</button>
        `;
        enfermerasList.appendChild(li);
    });
}

function asignarPokemon(enfermeraId) {
    alert(`¡Pokémon asignado a la enfermera con ID: ${enfermeraId}!`);
}

function cargarPokemonesPendientes() {
    const pokemonesList = document.getElementById('pokemones-pendientes');

    const pokemonesPendientes = [
        { id: 1, nombre: 'Pikachu', estado: 'herido' },
        { id: 2, nombre: 'Charmander', estado: 'envenenado' },
        { id: 3, nombre: 'Squirtle', estado: 'cansado' },
        { id: 4, nombre: 'Bulbasaur', estado: 'paralizado' },
        { id: 5, nombre: 'Eevee', estado: 'herido' },
        { id: 6, nombre: 'Jigglypuff', estado: 'dormido' }
    ];

    pokemonesPendientes.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${pokemon.nombre} (${pokemon.estado})</span>
            <button class="marcar-atendido" onclick="marcarAtendido(${pokemon.id})">Atender</button>
        `;
        pokemonesList.appendChild(li);
    });
}

function marcarAtendido(pokemonId) {
    alert(`¡Pokémon con ID ${pokemonId} marcado como atendido!`);
}

