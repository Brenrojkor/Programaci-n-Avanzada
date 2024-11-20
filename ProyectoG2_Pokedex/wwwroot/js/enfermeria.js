// Función para cargar el historial de atenciones desde la base de datos
function cargarHistorialAtenciones() {
    // Llamada AJAX para obtener el historial de atenciones
    fetch('/Home/GetHistorialAtenciones')
        .then(response => response.json())
        .then(data => {
            const historialList = document.getElementById('historial');
            historialList.innerHTML = '';

            data.forEach(atencion => {
                const li = document.createElement('li');
                li.innerHTML = `
                <strong>Pokémon: ${atencion.pokemon}</strong>
                <p>Descripción: ${atencion.descripcion}</p>
                <p><em>Fecha de Atención: ${new Date(atencion.fechaAtencion).toLocaleDateString()}</em></p>
                `;
                historialList.appendChild(li);
            });
        })
        .catch(error => {
            console.error('Error al cargar el historial:', error);
        });
}
