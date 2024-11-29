
document.addEventListener("DOMContentLoaded", function () {
    cargarEntrenadores();
    cargarRetos();
});

function cargarEntrenadores() {
    const entrenadoresList = document.getElementById('entrenadores');

    const entrenadores = [
        { id: 1, nombre: 'Ash Ketchum' },
        { id: 2, nombre: 'Misty' },
        { id: 3, nombre: 'Brock' },
        { id: 4, nombre: 'Gary Oak' },
        { id: 5, nombre: 'Jessie' },
        { id: 6, nombre: 'James' },
        { id: 7, nombre: 'Professor Oak' },
        { id: 8, nombre: 'May' },
        { id: 9, nombre: 'Max' },
        { id: 10, nombre: 'Cynthia' },
        { id: 11, nombre: 'Leon' },
        { id: 12, nombre: 'Roxanne' }
    ];

    entrenadores.forEach(entrenador => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${entrenador.nombre}</span>
            <button class="enviar-reto" onclick="enviarReto(${entrenador.id})">Reto</button>
        `;
        entrenadoresList.appendChild(li);
    });
}

function enviarReto(entrenadorId) {
    alert(`¡Reto enviado al entrenador con ID: ${entrenadorId}!`);
}

function cargarRetos() {
    const retosList = document.getElementById('retos');

    const retosPendientes = [
        { id: 1, nombre: 'Gary Oak', estado: 'pendiente' },
        { id: 2, nombre: 'Jessie James', estado: 'pendiente' },
        { id: 3, nombre: 'Ash Ketchum', estado: 'pendiente' },
        { id: 4, nombre: 'Misty Waterflower', estado: 'pendiente' },
        { id: 5, nombre: 'Brock Harrison', estado: 'pendiente' },
        { id: 6, nombre: 'Samuel Oak', estado: 'pendiente' },
        { id: 7, nombre: 'May Maple', estado: 'pendiente' },
        { id: 8, nombre: 'Maxxis Maple', estado: 'pendiente' },
        { id: 9, nombre: 'Cynthia Mieville', estado: 'pendiente' },
        { id: 10, nombre: 'Leon Mahogany', estado: 'pendiente' },
        { id: 11, nombre: 'Roxanne Stone', estado: 'pendiente' },
        { id: 12, nombre: 'Flannery Red', estado: 'pendiente' }
    ];

    retosPendientes.forEach(reto => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>Te ha retado el entrenador: ${reto.nombre}</span>
            <button class="aceptar-reto" onclick="aceptarReto(${reto.id})">Aceptar</button>
            <button class="rechazar-reto" onclick="rechazarReto(${reto.id})">Rechazar</button>
        `;
        retosList.appendChild(li);
    });
}

function aceptarReto(retoId) {
    alert(`¡Reto con ID ${retoId} aceptado!`);}

function rechazarReto(retoId) {
    alert(`Reto con ID ${retoId} rechazado.`);
}
