function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)
       

function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }

}

$(document).ready(function () {
    $('form').validate({
        rules: {
            Name: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            PhoneNumber: {
                required: false
            },
            Company: {
                required: false
            },
            Message: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            Name: {
                required: 'Vänligen ange ditt namn.'
            },
            Email: {
                required: 'Vänligen ange din e-postadress.',
                email: 'Vänligen ange en giltig e-postadress.'
            },
            Message: {
                required: 'Vänligen ange ett meddelande.',
                minlength: 'Meddelandet måste vara minst 5 tecken långt.'
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});



toggleMenu('[data-option="toggle"]')

