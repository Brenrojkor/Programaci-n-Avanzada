document.addEventListener("DOMContentLoaded", function () {
    renderPokemones();
});

const pokemones = [
    { id: 1, nombre: 'Pikachu' },
    { id: 2, nombre: 'Charmander' },
    { id: 3, nombre: 'Bulbasaur' },
    { id: 4, nombre: 'Squirtle' }
];

function renderPokemones() {
    const pokemonesList = document.getElementById('pokemones');
    pokemonesList.innerHTML = '';

    pokemones.forEach(pokemon => {
        const li = document.createElement('li');
        li.innerHTML =
            `<span>${pokemon.nombre}</span>
            <div>
                <button class="curar-pokemon" onclick="curarPokemon(${pokemon.id})">Curar</button>
            </div>`;
        pokemonesList.appendChild(li);
    });
}

function addPokemon() {
    const nuevoNombre = document.getElementById('nuevoPokemon').value.trim();
    if (nuevoNombre === '') {
        alert('Por favor, ingresa un nombre.');
        return;
    }

    const nuevoPokemon = {
        id: Date.now(),
        nombre: nuevoNombre
    };

    pokemones.push(nuevoPokemon);
    renderPokemones();
    document.getElementById('nuevoPokemon').value = '';
}

function curarPokemon(id) {
    const confirmar = confirm('¿Estás seguro de que deseas curar a este Pokémon?');
    if (confirmar) {
        const index = pokemones.findIndex(poke => poke.id === id);
        if (index !== -1) {
            pokemones.splice(index, 1);
            renderPokemones();
        }
    }
}