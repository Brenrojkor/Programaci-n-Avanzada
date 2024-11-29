const retosEnviados = [
    { id: 1, destinatario: 'Gary Oak', estado: 'Aceptado' },
    { id: 2, destinatario: 'Misty', estado: 'Pendiente' },
    { id: 3, destinatario: 'Brock', estado: 'Rechazado' }
];

const retosRecibidos = [
    { id: 1, remitente: 'Ash Ketchum', estado: 'Pendiente' },
    { id: 2, remitente: 'Jessie', estado: 'Aceptado' },
    { id: 3, remitente: 'James', estado: 'Rechazado' }
];

document.addEventListener("DOMContentLoaded", function () {
    cargarRetosEnviados();
    cargarRetosRecibidos();
});

function cargarRetosEnviados() {
    const retosEnviadosList = document.getElementById('retos-enviados');
    retosEnviadosList.innerHTML = ''; 

    retosEnviados.forEach(reto => {
        const li = document.createElement('li');
        li.innerHTML = `<span>Reto enviado a: ${reto.destinatario} - Estado: ${reto.estado}</span>`;
        retosEnviadosList.appendChild(li);
    });
}

function cargarRetosRecibidos() {
    const retosRecibidosList = document.getElementById('retos-recibidos');
    retosRecibidosList.innerHTML = '';

    retosRecibidos.forEach(reto => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>Reto recibido de: ${reto.remitente} - Estado: ${reto.estado}</span>
            <button class="aceptar-reto" onclick="aceptarReto(${reto.id})">Aceptar</button>
            <button class="rechazar-reto" onclick="rechazarReto(${reto.id})">Rechazar</button>
        `;
        retosRecibidosList.appendChild(li);
    });
}

function aceptarReto(retoId) {
    alert(`¡Has aceptado el reto con ID ${retoId}!`);
}

function rechazarReto(retoId) {
    alert(`Has rechazado el reto con ID ${retoId}.`);
}
