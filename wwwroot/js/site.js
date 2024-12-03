// Evento de scroll
window.addEventListener('scroll', function () {
    var scrollPosition = window.scrollY;
    var body = document.body;

    // Condicional para alterar a cor de fundo conforme a rolagem
    if (scrollPosition > 100) {
        body.style.backgroundColor = '#2c3e50'; // Cor após rolar 100px
    } else {
        body.style.backgroundColor = '#ecf0f1'; // Cor padrão
    }
});
