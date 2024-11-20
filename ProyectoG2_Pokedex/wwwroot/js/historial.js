// Función para cargar las peticiones de atención
function cargarPeticiones() {
    fetch('/Home/GetPeticionesAtencion')
        .then(response => response.json())
        .then(data => {
            const peticionesList = document.getElementById('peticiones');
            peticionesList.innerHTML = '';

            data.forEach(peticion => {
                const li = document.createElement('li');
                li.innerHTML = `
                <strong>Pokémon: ${peticion.pokemon}</strong>
                <p>Estado: ${peticion.estado}</p>
                <button class="atender-button" onclick="atenderPeticion(${peticion.peticionID})">Atender</button>
                `;
                peticionesList.appendChild(li);
            });
        })
        .catch(error => {
            console.error('Error al cargar las peticiones:', error);
        });
}

// Función para atender la petición
function atenderPeticion(peticionID) {
    alert('¡Petición atendida! ID: ' + peticionID);
    // Llamada AJAX para marcar la petición como atendida
    fetch(`/Home/AtenderPeticion/${peticionID}`, { method: 'POST' })
        .then(response => {
            if (response.ok) {
                alert('Petición atendida correctamente.');
                cargarPeticiones();  // Actualizar lista de peticiones
            } else {
                alert('Error al atender la petición.');
            }
        })
        .catch(error => {
            console.error('Error al atender la petición:', error);
        });
}
