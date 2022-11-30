(function () {

    window.formUtilities = {

        // For resizing textareas after render
        resizeTextArea: function (id) {
            let textArea = document.querySelector(`#${id}`);

            textArea.style.height = 'auto';
            textArea.style.height = (textArea.scrollHeight + 5) + 'px';

            const resizeOnInput = function () {
                this.style.height = "";
                this.style.height = (this.scrollHeight + 5) + "px"
            };

            textArea.addEventListener('input', resizeOnInput);
        }
    };
})();