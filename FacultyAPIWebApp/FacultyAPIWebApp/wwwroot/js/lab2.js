const uri = 'api/Departments';
let departments = [];

function getDepartments() {
    closeInput();
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayDepartments(data))
        .catch(error => console.error('Unable to get departments.', error));
}

function addDepartment() {
    const addNameTextbox = document.getElementById('add-name');

    const department = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(department)
    })
        .then(response => response.json())
        .then(() => {
            getDepartments();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add department.', error));
}

function deleteDepartment(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getDepartments())
        .catch(error => console.error('Unable to delete department.', error));
}

function displayEditForm(id) {
    const department = departments.find(department => department.id === id);

    document.getElementById('edit-id').value = department.id;
    document.getElementById('edit-name').value = department.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateDepartment() {
    const departmentId = document.getElementById('edit-id').value;
    const department = {
        id: parseInt(departmentId, 10),
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${departmentId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(department)
    })
        .then(() => getDepartments())
        .catch(error => console.error('Unable to update department.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayDepartments(data) {
    const tBody = document.getElementById('departments');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(department => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${department.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteDepartment(${department.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(department.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    departments = data;
}
