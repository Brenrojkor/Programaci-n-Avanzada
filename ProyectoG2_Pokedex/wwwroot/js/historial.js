document.addEventListener("DOMContentLoaded", () => {
    const params = new URLSearchParams(window.location.search);
    const name = params.get("name");
    const trainer = params.get("trainer");
    const status = params.get("status");

    if (name && trainer && status) {
        const historialContainer = document.getElementById("historial-container");
        const entry = document.createElement("div");
        entry.classList.add("historial-entry");
        entry.innerHTML = `
                <p><strong>Pokémon:</strong> ${name}</p>
                <p><strong>Entrenador:</strong> ${trainer}</p>
                <p><strong>Estado:</strong> ${status}</p>
            `;
        historialContainer.appendChild(entry);
    }
});
