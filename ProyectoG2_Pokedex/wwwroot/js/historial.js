const pokemonEnviados = [
    { id: 1, nombre: 'Pikachu', entrenador: 'Ash Ketchum', estado: 'Pendiente' },
    { id: 2, nombre: 'Charmander', entrenador: 'Gary Oak', estado: 'En tratamiento' },
    { id: 3, nombre: 'Bulbasaur', entrenador: 'Misty', estado: 'Pendiente' }
];

const pokemonTratados = [
    { id: 4, nombre: 'Squirtle', entrenador: 'Brock', resultado: 'Recuperado' },
    { id: 5, nombre: 'Eevee', entrenador: 'Jessie', resultado: 'Recuperado' }
];

document.addEventListener("DOMContentLoaded", function () {
    cargarPokemonEnviados();
    cargarPokemonTratados();
});

function cargarPokemonEnviados() {
    const pokemonEnviadosList = document.getElementById('pokemon-enviados');
    pokemonEnviadosList.innerHTML = '';
    pokemonEnviados.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${pokemon.nombre} (Entrenador: ${pokemon.entrenador}) - Estado: ${pokemon.estado}</span>
            <button class="iniciar-tratamiento" onclick="iniciarTratamiento(${pokemon.id})">Iniciar tratamiento</button>
        `;
        pokemonEnviadosList.appendChild(li);
    });
}

function cargarPokemonTratados() {
    const pokemonTratadosList = document.getElementById('pokemon-tratados');
    pokemonTratadosList.innerHTML = '';

    pokemonTratados.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${pokemon.nombre} (Entrenador: ${pokemon.entrenador}) - Resultado: ${pokemon.resultado}</span>
        `;
        pokemonTratadosList.appendChild(li);
    });
}

function iniciarTratamiento(pokemonId) {
    const pokemon = pokemonEnviados.find(p => p.id === pokemonId);
    if (pokemon) {
        pokemon.estado = 'En tratamiento';
        alert(`El tratamiento de ${pokemon.nombre} ha comenzado.`);
        cargarPokemonEnviados();
    }
}
