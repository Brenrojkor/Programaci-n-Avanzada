let pokemonEnviados = [
    { id: 1, nombre: 'Pikachu', entrenador: 'Ash Ketchum', estado: 'Pendiente' },
    { id: 2, nombre: 'Charmander', entrenador: 'Gary Oak', estado: 'En tratamiento' }
];

let pokemonTratados = [
    { id: 3, nombre: 'Bulbasaur', entrenador: 'Misty', resultado: 'Recuperado' }
];

let currentId = 4;

document.addEventListener("DOMContentLoaded", function () {
    cargarPokemonEnviados();
    cargarPokemonTratados();

    const form = document.getElementById('form-agregar-pokemon');
    form.addEventListener('submit', agregarPokemon);
});

function cargarPokemonEnviados() {
    const list = document.getElementById('pokemon-enviados');
    list.innerHTML = '';

    pokemonEnviados.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${pokemon.nombre} (Entrenador: ${pokemon.entrenador}) - Estado: ${pokemon.estado}</span>
            <button onclick="editarPokemonEnviado(${pokemon.id})">Editar</button>
            <button onclick="eliminarPokemonEnviado(${pokemon.id})">Eliminar</button>
            ${pokemon.estado === 'En tratamiento' ?
                `<button onclick="moverATratados(${pokemon.id})">Marcar como tratado</button>` : ''}
        `;
        list.appendChild(li);
    });
}

function cargarPokemonTratados() {
    const list = document.getElementById('pokemon-tratados');
    list.innerHTML = '';

    pokemonTratados.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${pokemon.nombre} (Entrenador: ${pokemon.entrenador}) - Resultado: ${pokemon.resultado}</span>
            <button onclick="eliminarPokemonTratado(${pokemon.id})">Eliminar</button>
        `;
        list.appendChild(li);
    });
}

function agregarPokemon(event) {
    event.preventDefault();

    const nombre = document.getElementById('nombre-pokemon').value;
    const entrenador = document.getElementById('entrenador-pokemon').value;
    const estado = document.getElementById('estado-pokemon').value;

    pokemonEnviados.push({
        id: currentId++,
        nombre,
        entrenador,
        estado
    });

    cargarPokemonEnviados();
    document.getElementById('form-agregar-pokemon').reset();
}

function editarPokemonEnviado(id) {
    const pokemon = pokemonEnviados.find(p => p.id === id);
    if (pokemon) {
        const nuevoNombre = prompt('Editar nombre del Pokémon:', pokemon.nombre);
        const nuevoEntrenador = prompt('Editar nombre del entrenador:', pokemon.entrenador);
        const nuevoEstado = prompt('Editar estado (Pendiente/En tratamiento):', pokemon.estado);

        if (nuevoNombre) pokemon.nombre = nuevoNombre;
        if (nuevoEntrenador) pokemon.entrenador = nuevoEntrenador;
        if (nuevoEstado) pokemon.estado = nuevoEstado;

        cargarPokemonEnviados();
    }
}

function eliminarPokemonEnviado(id) {
    pokemonEnviados = pokemonEnviados.filter(p => p.id !== id);
    cargarPokemonEnviados();
}

function moverATratados(id) {
    const pokemon = pokemonEnviados.find(p => p.id === id);
    if (pokemon) {
        pokemonEnviados = pokemonEnviados.filter(p => p.id !== id);
        pokemonTratados.push({
            ...pokemon,
            resultado: 'Recuperado'
        });
        cargarPokemonEnviados();
        cargarPokemonTratados();
    }
}

function eliminarPokemonTratado(id) {
    pokemonTratados = pokemonTratados.filter(p => p.id !== id);
    cargarPokemonTratados();
}
