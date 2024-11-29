document.addEventListener("DOMContentLoaded", function () {
    renderTrainers();
});

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

function renderTrainers() {
    const entrenadoresList = document.getElementById('entrenadores');
    entrenadoresList.innerHTML = ''; 

    entrenadores.forEach(entrenador => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${entrenador.nombre}</span>
            <div>
                <button class="edit-trainer" onclick="editTrainer(${entrenador.id})">Editar</button>
                <button class="delete-trainer" onclick="deleteTrainer(${entrenador.id})">Eliminar</button>
            </div>
        `;
        entrenadoresList.appendChild(li);
    });
}


function addTrainer() {
    const nuevoNombre = document.getElementById('nuevoEntrenador').value.trim();
    if (nuevoNombre === '') {
        alert('Por favor, ingresa un nombre.');
        return;
    }

    const nuevoEntrenador = {
        id: Date.now(), 
        nombre: nuevoNombre
    };

    entrenadores.push(nuevoEntrenador);
    renderTrainers();
    document.getElementById('nuevoEntrenador').value = ''; 
}


function editTrainer(id) {
    const nuevoNombre = prompt('Ingresa el nuevo nombre del entrenador:');
    if (nuevoNombre === null || nuevoNombre.trim() === '') {
        alert('No se realizaron cambios.');
        return;
    }

    const entrenador = entrenadores.find(ent => ent.id === id);
    if (entrenador) {
        entrenador.nombre = nuevoNombre;
        renderTrainers();
    }
}


function deleteTrainer(id) {
    const confirmar = confirm('¿Estás seguro de que deseas eliminar este entrenador?');
    if (confirmar) {
        const index = entrenadores.findIndex(ent => ent.id === id);
        if (index !== -1) {
            entrenadores.splice(index, 1); 
            renderTrainers();
        }
    }
}