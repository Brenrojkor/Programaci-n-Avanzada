const partidas = [
    { id: 1, entrenador: "Ash", resultado: "Ganada", fecha: "2024-11-28" },
    { id: 2, entrenador: "Misty", resultado: "Perdida", fecha: "2024-11-27" },
    { id: 3, entrenador: "Brock", resultado: "Ganada", fecha: "2024-11-26" },
    { id: 4, entrenador: "Gary", resultado: "Empatada", fecha: "2024-11-25" },
];

const historialContainer = document.getElementById('historial-container');

document.addEventListener("DOMContentLoaded", () => {
    if (partidas.length === 0) {
        historialContainer.innerHTML = "<p>No hay partidas en el historial.</p>";
        return;
    }

    const lista = document.createElement('ul');
    lista.classList.add('lista-partidas');

    partidas.forEach((partida) => {
        const item = document.createElement('li');
        item.classList.add('partida-item');
        item.innerHTML = `
            <div class="partida-detalles">
                <p><strong>Entrenador:</strong> ${partida.entrenador}</p>
                <p><strong>Resultado:</strong> ${partida.resultado}</p>
                <p><strong>Fecha:</strong> ${partida.fecha}</p>
            </div>
            <button class="ver-detalle" data-id="${partida.id}">Ver Detalle</button>
        `;
        lista.appendChild(item);
    });

    historialContainer.appendChild(lista);

    document.querySelectorAll('.ver-detalle').forEach((boton) => {
        boton.addEventListener('click', (e) => {
            const id = e.target.dataset.id;
            const partida = partidas.find(p => p.id == id);
            if (partida) {
                alert(`Detalle de Partida:\n\nEntrenador: ${partida.entrenador}\nResultado: ${partida.resultado}\nFecha: ${partida.fecha}`);
            }
        });
    });
});
