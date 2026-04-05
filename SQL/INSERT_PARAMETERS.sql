USE Movvi
GO

/* ================================
   CRIA TABELA SE NÃO EXISTIR
================================ */

IF NOT EXISTS (
    SELECT 1 
    FROM sys.tables 
    WHERE name = 'PARAMETERS'
)
BEGIN
    CREATE TABLE PARAMETERS(
        Id INT PRIMARY KEY IDENTITY(1,1),
        Parameter VARCHAR(255) NOT NULL UNIQUE,
        [VALUE] VARCHAR(MAX) NOT NULL
    )
END
GO


/* ================================
   INSERT DO TEMPLATE DE EMAIL
================================ */

IF NOT EXISTS (
    SELECT 1 
    FROM PARAMETERS 
    WHERE Parameter = 'EMAIL_TEMPLATE_DEFAULT'
)
BEGIN

INSERT INTO PARAMETERS (Parameter, [VALUE])
VALUES (
'EMAIL_TEMPLATE_DEFAULT',
'<!doctype html>
<html lang="pt-br">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Email Movvi</title>
</head>

<body style="margin:0;padding:0;background-color:#f4f6fb;font-family:Arial,Helvetica,sans-serif;">

<table width="100%" cellpadding="0" cellspacing="0" bgcolor="#f4f6fb">
<tr>
<td align="center">

<table width="600" cellpadding="0" cellspacing="0"
style="max-width:600px;background:#ffffff;border-radius:12px;overflow:hidden;box-shadow:0 4px 20px rgba(0,0,0,0.08);">

<tr>
<td align="center"
style="background:linear-gradient(135deg,#2e1f92,#4b3fcf);padding:30px;">

<img src="https://i.postimg.cc/9MX3GdV0/logo-white.png"
alt="Movvi Logo"
width="180"
style="display:block;margin-bottom:15px">

<h1 style="color:#ffffff;margin:0;font-size:24px;font-weight:600;">
Comunicação Movvi
</h1>

</td>
</tr>

<tr>
<td style="height:6px;background:#ff6a3d"></td>
</tr>

<tr>
<td style="padding:40px 35px;color:#333333;font-size:16px;line-height:1.6;">

<h2 style="color:#2e1f92;margin-top:0;">
{{TITULO_DA_MENSAGEM}}
</h2>

<p>
{{MENSAGEM}}
</p>

</td>
</tr>

<tr>
<td style="border-top:1px solid #eeeeee"></td>
</tr>

<tr>
<td align="center" style="padding:25px;color:#777777;font-size:13px;">
<p style="margin:0;">
© 2026 Movvi • Todos os direitos reservados
</p>
</td>
</tr>

</table>

</td>
</tr>
</table>

</body>
</html>'
)

END
GO