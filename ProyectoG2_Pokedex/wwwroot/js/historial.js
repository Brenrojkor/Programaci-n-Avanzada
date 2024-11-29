document.addEventListener("DOMContentLoaded", function () {
    cargarRetosEnviados();
    cargarRetosRecibidos();
});

async function cargarRetosEnviados() {
    try {
        const response = await fetch('/api/retos-enviados');
        const retosEnviados = await response.json();

        const retosEnviadosList = document.getElementById('retos-enviados');
        retosEnviadosList.innerHTML = ''; 

        retosEnviados.forEach(reto => {
            const li = document.createElement('li');
            li.innerHTML = `
                <span>Reto enviado a: ${reto.destinatario} - Estado: ${reto.estado}</span>
            `;
            retosEnviadosList.appendChild(li);
        });
    } catch (error) {
        console.error('Error al cargar los retos enviados:', error);
    }
}

async function cargarRetosRecibidos() {
    try {
        const response = await fetch('/api/retos-recibidos');
        const retosRecibidos = await response.json();

        const retosRecibidosList = document.getElementById('retos-recibidos');
        retosRecibidosList.innerHTML = '';

        retosRecibidos.forEach(reto => {
            const li = document.createElement('li');
            li.innerHTML = `
                <span>Reto recibido de: ${reto.remitente} - Estado: ${reto.estado}</span>
                <button class="aceptar-reto" data-id="${reto.id}">Aceptar</button>
                <button class="rechazar-reto" data-id="${reto.id}">Rechazar</button>
            `;
            retosRecibidosList.appendChild(li);
        });

        retosRecibidosList.addEventListener('click', function (event) {
            if (event.target.matches('.aceptar-reto')) {
                aceptarReto(event.target.dataset.id);
            } else if (event.target.matches('.rechazar-reto')) {
                rechazarReto(event.target.dataset.id);
            }
        });
    } catch (error) {
        console.error('Error al cargar los retos recibidos:', error);
    }
}

function aceptarReto(retoId) {
    alert(`¡Has aceptado el reto con ID ${retoId}!`);
}

function rechazarReto(retoId) {
    alert(`Has rechazado el reto con ID ${retoId}.`);
}
