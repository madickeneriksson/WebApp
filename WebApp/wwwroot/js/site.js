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
/*
$('form').each(function () {
    $(this).validate({
        rules: {
            FirstName: {
                required: true,
                minlength: 2
            },
            LastName: {
                required: true,
                minlength: 2
            },
            StreetName: {
                required: true,
                minlength: 2
            },
            PostalCode: {
                required: true,
                minlength: 2
            },
            City: {
                required: true,
                minlength: 2
            },
            Email: {
                required: true,
                email: true
            },

            Message: {
                required: true,
                minlength: 5
            },
            Password: {
                required: true,
                minlength: 2,
                pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{2,}$/
            },
            ArticleNumber: {
                required: true,
                minlength: 3
            },
            Name: {
                required: true,
                minlength: 2
            },
            Description: {
                required: false,
                minlength: 3
            },
            Price: {
                required: true,
                digits: true,
                min: 0
            }

        },
        messages: {
            FirstName: {
                required: 'Vänligen ange ditt förnamn.',
                minlength: 'Ange ett giltigt förnamn.'
            },
            LastName: {
                required: 'Vänligen ange ditt efternamn.',
                minlength: 'Ange ett giltigt efternamn.'
            },
            StreetName: {
                required: 'Vänligen ange gatunamn.',
                minlength: 'Ange ett giltigt gatunamn.'
            },
            PostalCode: {
                required: 'Vänligen ange ett postnummer.',
                digits: 'Vänligen ange endast siffror för postnumret.'
            },
            City: {
                required: 'Vänligen ange stad.',
                minlength: 'Ange en giltig stad.'
            },
            Email: {
                required: 'Vänligen ange din e-postadress.',
                email: 'Vänligen ange en giltig e-postadress.'
            },
            Message: {
                required: 'Vänligen ange ett meddelande.',
                minlength: 'Meddelandet måste vara minst 5 tecken långt.'
            },
            Password: {
                required: 'Vänligen ange ett lösenord.',
                minlength: 'Lösenordet måste vara minst 2 tecken långt och innehålla versal,siffra och specialtecken.',
                pattern: 'Lösenordet måste innehålla minst en versal, siffror och ett specialtecken.'
            },
            ArticleNumber: {
                required: 'Vänligen ange ett artikelnummer',
                minlength: 'Artikelnummret måste vara minst 3 tecken långt.'

            },
            Name: {
                required: 'Vänligen ange ett namn på produkten.',
                minlength: 'Namnet måste vara minst 2 tecken långt'
            },
            Description: {
                minlength: 'Beskrivningen bör vara minst 3 tecken lång'

            },
            Price: {
                required: 'Vänligen ange ett pris.',
                digits: 'Vänligen ange endast siffror.',
                min: 'Vänligen ange ett pris större än eller lika med 0.'
            }
        },

        submitHandler: function (form) {
            form.submit();
        }
    });
});
*/

const validateText = (event) => {
    if (event.target.value.length >= 2)
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "";
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Måste innehålla minst 2 tecken";
};

const validateEmail = (event) => {
    const regEx = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "";
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Ogiltig emailadress";
};

const validatePassword = (event) => {
    const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{2,}$/;

    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "";
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Felaktigt lösenord, måste innehålla versal,siffra och specialtecken";
};
const validatePrice = (event) => {
    const regEx = /^\d+$/;

    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "";
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Endast siffror";
};



toggleMenu('[data-option="toggle"]')

