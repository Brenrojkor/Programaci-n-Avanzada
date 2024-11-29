document.addEventListener("DOMContentLoaded", function () {
    cargarEnfermeras();
    cargarPokemonesPendientes();
});

let enfermeras = [
    { id: 1, nombre: 'Joy Kanto' },
    { id: 2, nombre: 'Joy Johto' }
];

let pokemonesPendientes = [
    { id: 1, nombre: 'Pikachu', estado: 'herido' },
    { id: 2, nombre: 'Charmander', estado: 'envenenado' }
];

function cargarEnfermeras() {
    const enfermerasList = document.getElementById('enfermeras');
    enfermerasList.innerHTML = '';

    enfermeras.forEach(enfermera => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${enfermera.nombre}</span>
            <button onclick="editarEnfermera(${enfermera.id})">Editar</button>
            <button onclick="eliminarEnfermera(${enfermera.id})">Eliminar</button>
        `;
        enfermerasList.appendChild(li);
    });
}

function crearEnfermera() {
    const nuevaEnfermera = document.getElementById('nuevaEnfermera').value;
    if (nuevaEnfermera.trim() === '') return alert('El nombre no puede estar vacío.');

    const nuevaId = enfermeras.length > 0 ? enfermeras[enfermeras.length - 1].id + 1 : 1;
    enfermeras.push({ id: nuevaId, nombre: nuevaEnfermera });
    document.getElementById('nuevaEnfermera').value = '';
    cargarEnfermeras();
}

function editarEnfermera(id) {
    const nombreActual = enfermeras.find(e => e.id === id).nombre;
    const nuevoNombre = prompt('Editar nombre de la enfermera:', nombreActual);

    if (nuevoNombre !== null && nuevoNombre.trim() !== '') {
        enfermeras = enfermeras.map(e => e.id === id ? { ...e, nombre: nuevoNombre } : e);
        cargarEnfermeras();
    }
}

function eliminarEnfermera(id) {
    if (confirm('¿Estás seguro de eliminar esta enfermera?')) {
        enfermeras = enfermeras.filter(e => e.id !== id);
        cargarEnfermeras();
    }
}

function cargarPokemonesPendientes() {
    const pokemonesList = document.getElementById('pokemones-pendientes');
    pokemonesList.innerHTML = '';

    pokemonesPendientes.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${pokemon.nombre} (${pokemon.estado})</span>
            <button onclick="editarPokemon(${pokemon.id})">Editar</button>
            <button onclick="eliminarPokemon(${pokemon.id})">Eliminar</button>
        `;
        pokemonesList.appendChild(li);
    });
}

function crearPokemon() {
    const nuevoPokemon = document.getElementById('nuevoPokemon').value;
    const estadoPokemon = document.getElementById('estadoPokemon').value;

    if (nuevoPokemon.trim() === '') return alert('El nombre no puede estar vacío.');

    const nuevaId = pokemonesPendientes.length > 0 ? pokemonesPendientes[pokemonesPendientes.length - 1].id + 1 : 1;
    pokemonesPendientes.push({ id: nuevaId, nombre: nuevoPokemon, estado: estadoPokemon });
    document.getElementById('nuevoPokemon').value = '';
    cargarPokemonesPendientes();
}

function editarPokemon(id) {
    const pokemonActual = pokemonesPendientes.find(p => p.id === id);
    const nuevoNombre = prompt('Editar nombre del Pokémon:', pokemonActual.nombre);
    const nuevoEstado = prompt('Editar estado del Pokémon:', pokemonActual.estado);

    if (nuevoNombre !== null && nuevoEstado !== null && nuevoNombre.trim() !== '' && nuevoEstado.trim() !== '') {
        pokemonesPendientes = pokemonesPendientes.map(p =>
            p.id === id ? { ...p, nombre: nuevoNombre, estado: nuevoEstado } : p
        );
        cargarPokemonesPendientes();
    }
}

function eliminarPokemon(id) {
    if (confirm('¿Estás seguro de eliminar este Pokémon?')) {
        pokemonesPendientes = pokemonesPendientes.filter(p => p.id !== id);
        cargarPokemonesPendientes();
    }
}
