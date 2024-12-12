document.addEventListener("DOMContentLoaded", function () {
    const tableList = document.getElementById("table-list").querySelector("tbody");
    const addButton = document.getElementById("add");

    // Función para agregar un Pokémon
    addButton.addEventListener("click", () => {
        const name = prompt("Enter Pokémon Name:");
        const type = prompt("Enter Pokémon Type:");
        const imageUrl = prompt("Enter Pokémon Image URL:");

        if (name && type && imageUrl) {
            const newRow = document.createElement("tr");
            newRow.innerHTML = `
                    <td><img src="${imageUrl}" alt="${name}" style="width:50px;height:50px;"></td>
                    <td>${name}</td>
                    <td>${type}</td>
                    <td>
                        <button class="btn btn-edit" style="background-color: blue; color: white;">Edit</button>
                        <button class="btn btn-delete" style="background-color: yellow; color: black;">Delete</button>
                    </td>
                `;
            tableList.appendChild(newRow);
            attachRowListeners(newRow);
        } else {
            alert("All fields are required!");
        }
    });

    // Función para editar o eliminar un Pokémon
    function attachRowListeners(row) {
        const editButton = row.querySelector(".btn-edit");
        const deleteButton = row.querySelector(".btn-delete");

        editButton.addEventListener("click", () => {
            const nameCell = row.children[1];
            const typeCell = row.children[2];

            const newName = prompt("Edit Pokémon Name:", nameCell.textContent);
            const newType = prompt("Edit Pokémon Type:", typeCell.textContent);

            if (newName && newType) {
                nameCell.textContent = newName;
                typeCell.textContent = newType;
            } else {
                alert("Both fields are required!");
            }
        });

        deleteButton.addEventListener("click", () => {
            if (confirm("Are you sure you want to delete this Pokémon?")) {
                row.remove();
            }
        });
    }

    // Añadir listeners a las filas existentes
    tableList.querySelectorAll("tr").forEach(attachRowListeners);
});
