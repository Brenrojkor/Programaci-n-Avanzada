document.addEventListener('DOMContentLoaded', renderEquipo);

const equipo = [
    { id: 1, nombre: 'Pikachu' },
    { id: 2, nombre: 'Charizard' },
    { id: 3, nombre: 'Bulbasaur' }
    { id: 4, nombre: 'Squirtle' },
    { id: 5, nombre: 'Jigglypuff' },
    { id: 6, nombre: 'Eevee' },
    { id: 7, nombre: 'Snorlax' },
    { id: 8, nombre: 'Gengar' },
    { id: 9, nombre: 'Dragonite' },
    { id: 10, nombre: 'Lucario' },
    { id: 11, nombre: 'Greninja' },
    { id: 12, nombre: 'Mewtwo' }
];


function CargarEquipo() {
    const equipoList = document.getElementById('equipoList');
    equipoList.innerHTML = ''; 

    equipo.forEach(miembro => {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${miembro.nombre}</span>
            <button onclick="editMiembro(${miembro.id})">Editar</button>
            <button onclick="deleteMiembro(${miembro.id})">Eliminar</button>
        `;
        equipoList.appendChild(li);
    });
}


function addMiembro() {
    const nombre = document.getElementById('nuevoMiembro').value;
    if (nombre.trim() === '') {
        alert('Ingrese un nombre para el Pokémon.');
        return;
    }
    equipo.push({ id: Date.now(), nombre });
    document.getElementById('nuevoMiembro').value = ''; 
    CargarEquipo();
}

function editMiembro(id) {
    const nuevoNombre = prompt('Nuevo nombre del Pokémon:');
    if (nuevoNombre.trim() === '') {
        alert('El nombre no puede estar vacío.');
        return;
    }
    const miembro = equipo.find(m => m.id === id);
    if (miembro) {
        miembro.nombre = nuevoNombre;
        CargarEquipo();
    }
}


function deleteMiembro(id) {
    const index = equipo.findIndex(m => m.id === id);
    if (index !== -1) {
        equipo.splice(index, 1);
        CargarEquipo();
    }
}


