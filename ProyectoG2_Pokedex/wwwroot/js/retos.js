// Esperamos a que el DOM se cargue completamente
document.addEventListener("DOMContentLoaded", function () {
    // Llamamos a las funciones para cargar los entrenadores y retos pendientes
    cargarEntrenadores();
    cargarRetos();
});

// Función para cargar los entrenadores disponibles
function cargarEntrenadores() {
    const entrenadoresList = document.getElementById('entrenadores');

    // Simulación de datos de entrenadores (esto normalmente vendría de una API)
    const entrenadores = [
        { id: 1, nombre: 'Ash Ketchum' },
        { id: 2, nombre: 'Misty' },
        { id: 3, nombre: 'Brock' }
    ];

    // Recorremos el array de entrenadores y los agregamos al HTML
    entrenadores.forEach(entrenador => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${entrenador.nombre}</span>
            <button class="enviar-reto" onclick="enviarReto(${entrenador.id})">Reto</button>
        `;
        entrenadoresList.appendChild(li);
    });
}

// Función para enviar un reto a un entrenador
function enviarReto(entrenadorId) {
    alert(`¡Reto enviado al entrenador con ID: ${entrenadorId}!`);
    // Aquí puedes agregar la lógica para hacer la llamada al backend para enviar el reto
}

// Función para cargar los retos pendientes
function cargarRetos() {
    const retosList = document.getElementById('retos');

    // Simulación de retos pendientes (esto normalmente vendría de una API)
    const retosPendientes = [
        { id: 1, nombre: 'Gary Oak', estado: 'pendiente' },
        { id: 2, nombre: 'Jessie', estado: 'pendiente' }
    ];

    // Recorremos el array de retos y los agregamos al HTML
    retosPendientes.forEach(reto => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>Reto de ${reto.nombre}</span>
            <button class="aceptar-reto" onclick="aceptarReto(${reto.id})">Aceptar</button>
            <button class="rechazar-reto" onclick="rechazarReto(${reto.id})">Rechazar</button>
        `;
        retosList.appendChild(li);
    });
}

// Función para aceptar un reto
function aceptarReto(retoId) {
    alert(`¡Reto con ID ${retoId} aceptado!`);
    // Aquí puedes agregar la lógica para hacer la llamada al backend para aceptar el reto
}

// Función para rechazar un reto
function rechazarReto(retoId) {
    alert(`Reto con ID ${retoId} rechazado.`);
    // Aquí puedes agregar la lógica para hacer la llamada al backend para rechazar el reto
}
