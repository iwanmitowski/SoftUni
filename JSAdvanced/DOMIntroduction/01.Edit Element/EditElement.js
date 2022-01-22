function editElement(headerElement, oldVal, newVal) {
    headerElement.textContent = headerElement.textContent.replace(RegExp(oldVal, 'g'), newVal);
}