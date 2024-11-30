
document.addEventListener("DOMContentLoaded", () => {
    const pokemonList = [
        { id: 1, name: "Pikachu", trainer: "Ash Ketchum" },
        { id: 2, name: "Charizard", trainer: "Red" },
        { id: 3, name: "Bulbasaur", trainer: "Brock" },
    ];

    const container = document.getElementById("pokemon-list");

    pokemonList.forEach(pokemon => {
        const pokemonItem = document.createElement("div");
        pokemonItem.classList.add("pokemon-item");
        pokemonItem.innerHTML = `
            <p><strong>${pokemon.name}</strong> - Entrenador: ${pokemon.trainer}</p>
            <button class="btn heal-btn" onclick="healPokemon(${pokemon.id}, '${pokemon.name}', '${pokemon.trainer}')">
                Sanar
            </button>
        `;
        container.appendChild(pokemonItem);
    });
});

function healPokemon(id, name, trainer) {
    const url = `/Historial?name=${encodeURIComponent(name)}&trainer=${encodeURIComponent(trainer)}&status=Sanado`;
    window.location.href = url;
}
