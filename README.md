# ProjectTodo

## Executar projeto C#
Para executar o projeto é necessário configurar o arquivo appsettings.json, passando as informações do banco de dados.
### "Server=*; DataBase=*;Uid=*;Pwd=*"
## O banco de dados utilizado foi o MYSQL.

### É preciso instalar o entity framework globalmente
Após isso abra um prompt de comando onde o projeto estiver localizado e digite o comando "dotnet ef database update".
Ele mapeará a Migration que esta no projeto e criará as tabelas no banco de dados.
Apos isso é só executar o projeto e testa-lo.

## Executar testes com robotframework
### É preciso ter instalado na sua maquina o python.
Primeiramente abra um prompt de comando na pasta do projeto e digite "pip install -r requirements.txt".
Ele irá baixar todas as dependências necessárias para executar os testes com robot.

