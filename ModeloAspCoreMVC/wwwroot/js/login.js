$('#login').click(function () {
    $.ajax({
        method: 'POST',
        url: '/login',
        data: JSON.stringify({ Login: $('#user_login').val(), Senha: $('#user_pass').val() }),
        contentType: 'application/json',
        success: function (e) { window.location = "/" + e;}
    });
});

