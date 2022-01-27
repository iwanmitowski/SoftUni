function deleteByEmail() {
    let trElements = document.querySelectorAll('tbody tr');

    let email = document.querySelector('input[type="text"]').value;

    let result = document.getElementById('result');

    for (const tr of trElements) {
        if (email != '' && tr.textContent.includes(email)) {
            tr.remove();
            result.textContent = 'Deleted.'
            return;
        }
    }

    result.textContent = 'Not found.';
}